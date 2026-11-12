using System;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    /// <summary>
    ///     Request to issue one service invoice (NFS-e) for a financial context through the fiscal provider.
    ///     The service classification is chosen only from the curated fiscal catalog (<see cref="ServiceKey"/>),
    ///     never from free text, so issuing never registers ad-hoc services at the provider.
    /// </summary>
    public class FiscalIssueRequest
    {
        /// <summary>Financial context (customer) that receives the invoice.</summary>
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>Key of the curated fiscal service, see GET Finance/Fiscal/Services.</summary>
        [JsonPropertyName("servicekey")]
        public string ServiceKey { get; set; } = string.Empty;

        /// <summary>Text printed on the invoice describing what was provided.</summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>Optional complementary observations printed on the invoice.</summary>
        [JsonPropertyName("observations")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Observations { get; set; }

        /// <summary>Invoice amount.</summary>
        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        /// <summary>Optional effective date; defaults to the current date in Brazil.</summary>
        [JsonPropertyName("effectivedate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? EffectiveDate { get; set; }

        /// <summary>Optional provider payment identifier the invoice settles (e.g. Asaas pay_...).</summary>
        [JsonPropertyName("payment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Payment { get; set; }

        /// <summary>
        ///     Optional internal idempotency reference (e.g. contract id). The same reference never
        ///     produces a second active invoice.
        /// </summary>
        [JsonPropertyName("reference")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Reference { get; set; }
    }
}
