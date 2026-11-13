#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sufficit.Exchange.Templates
{
    /// <summary>Result of rendering a message template; never sent when <see cref="Errors"/> is not empty.</summary>
    public sealed class MessageTemplateRenderResult
    {
        public string? Subject { get; set; }
        public string Body { get; set; } = string.Empty;
        /// <summary>Human readable problems (missing required value, unknown placeholder, invalid value).</summary>
        public List<string> Errors { get; set; } = new List<string>();
        public bool Success => Errors.Count == 0;
    }

    /// <summary>
    ///     Renders <see cref="MessageTemplate"/> contents with a small, strict syntax so operators cannot send a
    ///     message with a forgotten or mistyped value:
    ///     <list type="bullet">
    ///         <item><c>{{name}}</c>: scalar value. Unknown names are errors.</item>
    ///         <item><c>{{#list}}</c> … <c>{{/list}}</c>: lines repeated for every item of a list value; inside, <c>{{field}}</c>
    ///             reads the item first and then the scalar values.</item>
    ///         <item>A line whose placeholders all resolve to an empty value is removed (optional lines, e.g. call balance).</item>
    ///     </list>
    ///     Declared <see cref="TemplateVariable"/>s supply defaults, required checks and validation patterns.
    ///     Line breaks are normalized to <c>\n</c> and trailing blank lines are trimmed; text and emojis are kept as written.
    /// </summary>
    public static class MessageTemplateRenderer
    {
        private static readonly Regex Placeholder = new Regex(@"\{\{\s*([#/]?)([A-Za-z0-9_.]+)\s*\}\}", RegexOptions.Compiled);

        /// <summary>Renders the content stored for <paramref name="messageType"/> (e.g. "whatsapp", "email").</summary>
        public static MessageTemplateRenderResult Render(MessageTemplate template, string messageType,
            IReadOnlyDictionary<string, string?> values, IReadOnlyDictionary<string, IReadOnlyList<IReadOnlyDictionary<string, string?>>>? lists = null)
        {
            if (template == null) throw new ArgumentNullException(nameof(template));
            var result = new MessageTemplateRenderResult();
            if (!template.Contents.TryGetValue(messageType, out var content) || content == null || string.IsNullOrWhiteSpace(content.Body))
            {
                result.Errors.Add($"Template '{template.Title}' has no '{messageType}' content.");
                return result;
            }

            lists ??= new Dictionary<string, IReadOnlyList<IReadOnlyDictionary<string, string?>>>();
            var scalars = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
            foreach (var pair in values ?? new Dictionary<string, string?>()) scalars[pair.Key] = pair.Value;

            foreach (var variable in template.Variables.Values.Where(v => v != null))
            {
                var name = string.IsNullOrWhiteSpace(variable.Name) ? null : variable.Name;
                if (name == null) continue;
                if (lists.ContainsKey(name))
                {
                    if (variable.IsRequired && lists[name].Count == 0) result.Errors.Add($"List '{name}' is required and is empty.");
                    continue;
                }
                scalars.TryGetValue(name, out var value);
                if (!scalars.ContainsKey(name)) scalars[name] = null;
                if (string.IsNullOrWhiteSpace(value) && !string.IsNullOrEmpty(variable.DefaultValue)) scalars[name] = value = variable.DefaultValue;
                if (string.IsNullOrWhiteSpace(value))
                {
                    if (variable.IsRequired) result.Errors.Add($"Value '{name}' is required.");
                    continue;
                }
                if (!string.IsNullOrEmpty(variable.ValidationPattern) && !Regex.IsMatch(value!, variable.ValidationPattern!))
                    result.Errors.Add($"Value '{name}' does not match the expected format.");
            }

            result.Subject = content.Subject == null ? null : RenderText(content.Subject, scalars, lists, result.Errors);
            result.Body = RenderText(content.Body, scalars, lists, result.Errors);
            return result;
        }

        private static string RenderText(string text, IDictionary<string, string?> scalars,
            IReadOnlyDictionary<string, IReadOnlyList<IReadOnlyDictionary<string, string?>>> lists, List<string> errors)
        {
            var lines = text.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n');
            var output = new List<string>();
            for (var i = 0; i < lines.Length; i++)
            {
                var open = Placeholder.Match(lines[i]);
                if (open.Success && open.Groups[1].Value == "#" && lines[i].Trim() == open.Value)
                {
                    var name = open.Groups[2].Value;
                    var end = Array.FindIndex(lines, i + 1, l => Regex.IsMatch(l.Trim(), @"^\{\{\s*/" + Regex.Escape(name) + @"\s*\}\}$"));
                    if (end < 0) { errors.Add($"Block '{name}' is not closed."); return string.Empty; }
                    var block = lines.Skip(i + 1).Take(end - i - 1).ToArray();
                    if (!lists.TryGetValue(name, out var items)) errors.Add($"List '{name}' was not provided.");
                    else
                        foreach (var item in items)
                            foreach (var line in block)
                                AddLine(output, line, key => item.TryGetValue(key, out var v) ? (true, v) : Scalar(scalars, key), errors);
                    i = end;
                    continue;
                }
                AddLine(output, lines[i], key => Scalar(scalars, key), errors);
            }

            // Collapse runs of blank lines left by removed optional lines and trim the edges.
            var compact = new List<string>();
            foreach (var line in output)
                if (line.Trim().Length > 0 || (compact.Count > 0 && compact[compact.Count - 1].Trim().Length > 0)) compact.Add(line);
            while (compact.Count > 0 && compact[compact.Count - 1].Trim().Length == 0) compact.RemoveAt(compact.Count - 1);
            return string.Join("\n", compact);
        }

        private static (bool found, string? value) Scalar(IDictionary<string, string?> scalars, string key)
            => scalars.TryGetValue(key, out var value) ? (true, value) : (false, null);

        private static void AddLine(List<string> output, string line, Func<string, (bool found, string? value)> resolve, List<string> errors)
        {
            var matches = Placeholder.Matches(line).Cast<Match>().ToList();
            if (matches.Count == 0) { output.Add(line.TrimEnd()); return; }
            var anyValue = false;
            var builder = new StringBuilder();
            var last = 0;
            foreach (var match in matches)
            {
                builder.Append(line, last, match.Index - last);
                last = match.Index + match.Length;
                if (match.Groups[1].Value.Length > 0) { errors.Add($"Block marker '{match.Value}' must be alone on its line."); continue; }
                var (found, value) = resolve(match.Groups[2].Value);
                if (!found) { errors.Add($"Unknown placeholder '{match.Value}'."); continue; }
                if (!string.IsNullOrWhiteSpace(value)) anyValue = true;
                builder.Append(value);
            }
            builder.Append(line, last, line.Length - last);
            if (anyValue) output.Add(builder.ToString().TrimEnd());
        }
    }
}
