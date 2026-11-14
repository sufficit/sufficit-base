using System;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    /// <summary>Decision not to issue the invoice of a receipt line (or to restore it).</summary>
    public class FiscalDismissRequest
    {
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>Line reference (<see cref="FiscalReceiptLine.Reference"/>).</summary>
        [JsonPropertyName("reference")]
        public string Reference { get; set; } = string.Empty;

        /// <summary>Why no invoice is issued (5..500 characters); ignored when restoring.</summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; } = string.Empty;
    }
}
