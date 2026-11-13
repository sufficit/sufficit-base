#nullable enable
using System;
using System.Collections.Generic;

namespace Sufficit.Exchange.Templates
{
    /// <summary>Request to render an approved template with the values of one message (POST Exchange/Template/Render).</summary>
    public sealed class MessageTemplateRenderRequest
    {
        public Guid ContextId { get; set; }
        public string Title { get; set; } = string.Empty;
        /// <summary>Content key, e.g. "whatsapp" or "email".</summary>
        public string MessageType { get; set; } = string.Empty;
        public Dictionary<string, string?> Values { get; set; } = new Dictionary<string, string?>();
        /// <summary>List values for {{#name}} blocks, each item a field/value map.</summary>
        public Dictionary<string, List<Dictionary<string, string?>>> Lists { get; set; } = new Dictionary<string, List<Dictionary<string, string?>>>();

        /// <summary>Converts <see cref="Lists"/> to the renderer input.</summary>
        public IReadOnlyDictionary<string, IReadOnlyList<IReadOnlyDictionary<string, string?>>> ListValues()
        {
            var result = new Dictionary<string, IReadOnlyList<IReadOnlyDictionary<string, string?>>>();
            foreach (var pair in Lists)
            {
                var items = new List<IReadOnlyDictionary<string, string?>>();
                foreach (var item in pair.Value ?? new List<Dictionary<string, string?>>()) items.Add(item);
                result[pair.Key] = items;
            }
            return result;
        }
    }
}
