using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class BillingValueRequestParameters
    {
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        [JsonPropertyName("linkedid")]
        public string? LinkedId { get; set; }

        [JsonPropertyName("uniqueid")]
        public string? UniqueId { get; set; }

        [Obsolete("2024/08/05 use LinkedId instead")]
        [JsonPropertyName("protocol")]
        public string? Protocol { get => LinkedId; set => LinkedId = value; }
    }
}
