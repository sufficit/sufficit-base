using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Billing
{
    /// <summary>
    ///   Electronic Invoice object, governament invoicing
    /// </summary>
    public class ElectronicInvoice
    {
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid Id { get; set; }

        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        [JsonPropertyName("source")]
        public EletronicInvoiceSourceInfo Source { get; set; } = new EletronicInvoiceSourceInfo();

        [JsonPropertyName("creation")]
        public DateTimeOffset Creation { get; set; }

        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        [JsonPropertyName("xml")]
        public Guid? XML { get; set; }

        [JsonPropertyName("pdf")]
        public Guid? PDF { get; set; }
    }
}
