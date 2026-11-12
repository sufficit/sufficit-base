using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    /// <summary>Invoice taker (tomador) address as registered at the fiscal provider.</summary>
    public class FiscalTakerAddress
    {
        [JsonPropertyName("street")]
        public string Street { get; set; } = string.Empty;

        [JsonPropertyName("number")]
        public string Number { get; set; } = string.Empty;

        [JsonPropertyName("complement")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Complement { get; set; }

        [JsonPropertyName("district")]
        public string District { get; set; } = string.Empty;

        /// <summary>Brazilian CEP, digits only.</summary>
        [JsonPropertyName("postalcode")]
        public string PostalCode { get; set; } = string.Empty;
    }

    /// <summary>Invoice taker as seen by the fiscal provider.</summary>
    public class FiscalTakerView
    {
        [JsonPropertyName("contextid")]
        public System.Guid ContextId { get; set; }

        [JsonPropertyName("provider")]
        public string Provider { get; set; } = string.Empty;

        [JsonPropertyName("customer")]
        public string Customer { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FiscalTakerAddress? Address { get; set; }

        /// <summary>True when street, number, district and CEP are present (required by the municipality).</summary>
        [JsonPropertyName("complete")]
        public bool Complete { get; set; }
    }
}
