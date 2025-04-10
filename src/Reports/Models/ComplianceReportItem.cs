using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Reports.Models
{
    public class ComplianceReportItem
    {
        [JsonPropertyName("did")]
        public string DID { get; set; } = default!;

        [JsonPropertyName("provider")]
        public IIdTitlePair Provider { get; set; } = default!;

        [JsonPropertyName("customer")]
        public IIdTitlePair Customer { get; set; } = default!;

        [JsonPropertyName("document")]
        public string? Document { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("email")]
        public string? EMail { get; set; }
    }
}
