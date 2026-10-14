using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Sufficit.Sales;

public sealed class ServiceCheckoutDetail
{
    public ServiceCheckoutDetail(string label, string value, string? unit)
    {
        Label = label;
        Value = value;
        Unit = unit;
    }

    public string Label { get; }
    public string Value { get; }
    public string? Unit { get; }
}

/// <summary>Explicit customer-visible contract parameters; never changes the billed amount.</summary>
public static class ServiceCheckoutComposition
{
    public const string SelectionKey = "checkout.visibleParameters";
    public const int MaximumDetails = 20;

    public static HashSet<string> Selected(IReadOnlyDictionary<string, string> values)
    {
        if (!values.TryGetValue(SelectionKey, out var raw) || raw.Length > 4096) return new(StringComparer.Ordinal);
        try
        {
            var keys = JsonSerializer.Deserialize<string[]>(raw);
            return new HashSet<string>((keys ?? Array.Empty<string>())
                .Where(k => !string.IsNullOrWhiteSpace(k) && k.Length <= 64 && !k.StartsWith("checkout.", StringComparison.Ordinal))
                .Take(MaximumDetails), StringComparer.Ordinal);
        }
        catch (System.Text.Json.JsonException) { return new(StringComparer.Ordinal); }
    }

    public static void Set(IDictionary<string, string> values, string key, bool visible)
    {
        if (string.IsNullOrWhiteSpace(key) || key.Length > 64 || key.StartsWith("checkout.", StringComparison.Ordinal))
            throw new ArgumentException("Invalid public parameter key.", nameof(key));
        var selected = Selected(new Dictionary<string, string>(values));
        if (visible)
        {
            if (!selected.Contains(key) && selected.Count >= MaximumDetails)
                throw new InvalidOperationException("Selecione até 20 parâmetros para o checkout.");
            selected.Add(key);
        }
        else selected.Remove(key);
        if (selected.Count == 0) values.Remove(SelectionKey);
        else values[SelectionKey] = JsonSerializer.Serialize(selected.OrderBy(k => k, StringComparer.Ordinal));
    }

    public static IReadOnlyList<ServiceCheckoutDetail> Build(IEnumerable<ServiceCatalogParameterDefinition> definitions,
        IReadOnlyDictionary<string, string> values)
    {
        var selected = Selected(values);
        return definitions.OrderBy(p => p.DisplayOrder).ThenBy(p => p.Key, StringComparer.Ordinal)
            .Where(p => selected.Contains(p.Key) && values.TryGetValue(p.Key, out var v)
                && !string.IsNullOrWhiteSpace(v) && v.Length <= 250 && !v.Any(char.IsControl)
                && !string.IsNullOrWhiteSpace(p.Label) && p.Label.Length <= 120 && !p.Label.Any(char.IsControl))
            .Take(MaximumDetails).Select(p => new ServiceCheckoutDetail(p.Label.Trim(),
                p.Type == ServiceParameterType.Boolean && bool.TryParse(values[p.Key], out var boolean)
                    ? boolean ? "Sim" : "Não" : values[p.Key].Trim(),
                p.Unit is { Length: <= 32 } unit && !unit.Any(char.IsControl) ? unit.Trim() : null)).ToArray();
    }
}
