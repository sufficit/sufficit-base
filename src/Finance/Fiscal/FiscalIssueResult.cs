using System;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    /// <summary>
    ///     Provider-side state of an issued service invoice. Scheduling is asynchronous: the municipal
    ///     authorization arrives later and is imported as an <see cref="ElectronicInvoice"/>.
    /// </summary>
    public class FiscalIssueResult
    {
        /// <summary>Deterministic id of the internal <see cref="ElectronicInvoice"/> once imported.</summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>Provider system, e.g. ASAAS.</summary>
        [JsonPropertyName("provider")]
        public string Provider { get; set; } = string.Empty;

        /// <summary>Provider invoice identifier, e.g. inv_...</summary>
        [JsonPropertyName("providerid")]
        public string ProviderId { get; set; } = string.Empty;

        /// <summary>Provider status: SCHEDULED, SYNCHRONIZED, AUTHORIZED, CANCELED, ERROR...</summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("statusdescription")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? StatusDescription { get; set; }

        [JsonPropertyName("value")]
        public decimal? Value { get; set; }

        [JsonPropertyName("effectivedate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? EffectiveDate { get; set; }

        [JsonPropertyName("payment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Payment { get; set; }

        [JsonPropertyName("number")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Number { get; set; }

        [JsonPropertyName("servicecode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ServiceCode { get; set; }

        [JsonPropertyName("pdf")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Uri? PdfUrl { get; set; }

        /// <summary>True when an equivalent active invoice already existed and nothing new was scheduled.</summary>
        [JsonPropertyName("duplicate")]
        public bool Duplicate { get; set; }
    }
}
