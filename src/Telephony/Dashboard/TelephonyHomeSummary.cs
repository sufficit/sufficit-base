using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Dashboard
{
    /// <summary>
    /// Compact telephony summary used by the authenticated home dashboard.
    /// </summary>
    public sealed class TelephonyHomeSummary
    {
        [JsonPropertyName("totalEndpoints")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? TotalEndpoints { get; set; }

        [JsonPropertyName("statesWithCoverage")]
        public uint StatesWithCoverage { get; set; }

        [JsonPropertyName("leadingState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? LeadingState { get; set; }

        [JsonPropertyName("leadingAreaCode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? LeadingAreaCode { get; set; }

        [JsonPropertyName("leadingStateShare")]
        public double LeadingStateShare { get; set; }

        [JsonPropertyName("generatedAtUtc")]
        public DateTime GeneratedAtUtc { get; set; }
    }
}
