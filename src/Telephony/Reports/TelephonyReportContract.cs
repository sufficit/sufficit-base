using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Sufficit.Telephony.Reports
{
    /// <summary>Versioned, stateless report request shared by API, agents and Blazor. UTC instants; inclusive end.</summary>
    public sealed class TelephonyReportRequest
    {
        public Guid ContextId { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public int OffsetMinutes { get; set; } = -180;
        public string[] Dids { get; set; } = Array.Empty<string>();
        public string? Filter { get; set; }
        public uint DiscardSeconds { get; set; }
        public bool IncludeSpreadsheet { get; set; }
    }

    public sealed class TelephonyReportModel
    {
        public string Key { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        /// <summary>Zero means no maximum duration. Retained for catalog compatibility.</summary>
        public int MaximumHours { get; set; }
        public bool SupportsCallFilters { get; set; }
        public bool SupportsDiscard { get; set; }
    }

    /// <summary>Completed snapshot. Cells retain numeric values; no partial data is returned as success.</summary>
    public sealed class TelephonyReportResult
    {
        public int SchemaVersion { get; set; } = 1;
        public string Model { get; set; } = string.Empty;
        public Guid ContextId { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public int OffsetMinutes { get; set; }
        public DateTimeOffset GeneratedAt { get; set; }
        public string Title { get; set; } = string.Empty;
        public string[] Columns { get; set; } = Array.Empty<string>();
        public JsonElement[][] Rows { get; set; } = Array.Empty<JsonElement[]>();
        public Dictionary<string, decimal> Totals { get; set; } = new();
        public string[] Notes { get; set; } = Array.Empty<string>();
        public string? SpreadsheetBase64 { get; set; }
    }
}
