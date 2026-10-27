using System;
using System.Collections.Generic;

namespace Sufficit.Cadences
{
    /// <summary>Date that step offsets are counted from. The consumer supplies the actual date for each case.</summary>
    public static class CadenceAnchors
    {
        public const string DueDate = "due-date";
        public const string CoverageEnd = "coverage-end";
        public const string PeriodStart = "period-start";
        public const string EventDate = "event-date";

        public static IReadOnlyDictionary<string, string> All { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            [DueDate] = "Vencimento",
            [CoverageEnd] = "Fim da cobertura",
            [PeriodStart] = "Início do período",
            [EventDate] = "Data do evento",
        };

        public static string Title(string? key) => key != null && All.TryGetValue(key, out var title) ? title : key ?? "";
    }
}
