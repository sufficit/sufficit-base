using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Billing
{
    /// <summary>
    ///     Source information for electronic invoices, such as the system that generated the invoice, its external ID, and current status.
    /// </summary>
    public class EletronicInvoiceSourceInfo
    {
        /// <summary>
        ///     System that generated the invoice, e.g. "ASAAS", "GERENCIANET", etc.
        /// </summary>
        /// <remarks>* Upstring normalized</remarks>
        [JsonPropertyName("system")]
        public string System { get; set; } = default!;

        /// <summary>
        ///     External Id, used to identify the invoice on source systems
        /// </summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Id { get; set; }

        /// <summary>
        ///     Current status of the invoice on the source system
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = default!;
    }
}
