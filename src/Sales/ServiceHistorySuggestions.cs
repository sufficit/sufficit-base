using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Sales;

/// <summary>A customer with different Brazilian start days in the reviewed month; not a confirmed error.</summary>
public sealed class ServiceHistorySuggestion
{
    /// <summary>Customer identity used to open the scoped review.</summary>
    public Guid ContextId { get; set; }
    /// <summary>Customer display name from the canonical customer projection.</summary>
    public string? Title { get; set; }
    /// <summary>Number of records considered for this customer.</summary>
    public int RecordCount { get; set; }
    /// <summary>Distinct Brazilian civil start days; no day is declared correct.</summary>
    public int[] StartDays { get; set; } = Array.Empty<int>();
}

/// <summary>Bounded suggestion result with explicit coverage, including confirmed empty results.</summary>
public sealed class ServiceHistorySuggestions
{
    /// <summary>Reviewed Brazilian civil month in yyyy-MM format.</summary>
    public string Month { get; set; } = string.Empty;
    /// <summary>Number of source records inspected.</summary>
    public int InspectedRecords { get; set; }
    /// <summary>True when the source limit was reached; absence is then inconclusive.</summary>
    public bool IsTruncated { get; set; }
    /// <summary>Customers suggested for human review.</summary>
    public ServiceHistorySuggestion[] Items { get; set; } = Array.Empty<ServiceHistorySuggestion>();
}

/// <summary>Groups reviewed records without inferring a correct billing day or changing any customer data.</summary>
public static class ServiceHistorySuggestionPolicy
{
    /// <summary>Maximum records inspected in one monthly suggestion request.</summary>
    public const int RecordLimit = 500;
    private static readonly TimeZoneInfo Zone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");

    /// <summary>Builds deterministic suggestions from an explicitly bounded monthly source.</summary>
    public static ServiceHistorySuggestions Build(string month, IEnumerable<SalesRecord> records,
        IReadOnlyDictionary<Guid, string?> customerNames)
    {
        var rows = records.ToArray();
        if (rows.Length > RecordLimit) throw new ArgumentException("Suggestion source exceeds its limit.");
        var items = rows.Where(x => x.ContextId != Guid.Empty).GroupBy(x => x.ContextId)
            .Select(group => new ServiceHistorySuggestion { ContextId = group.Key,
                Title = customerNames.TryGetValue(group.Key, out var title) ? title : null, RecordCount = group.Count(),
                StartDays = group.Select(x => TimeZoneInfo.ConvertTimeFromUtc(
                    DateTime.SpecifyKind(x.Start, DateTimeKind.Utc), Zone).Day).Distinct().OrderBy(x => x).ToArray() })
            .Where(x => x.StartDays.Length > 1).OrderBy(x => x.Title ?? x.ContextId.ToString("D"), StringComparer.OrdinalIgnoreCase)
            .ThenBy(x => x.ContextId).ToArray();
        return new ServiceHistorySuggestions { Month = month, InspectedRecords = rows.Length,
            IsTruncated = rows.Length == RecordLimit, Items = items };
    }
}
