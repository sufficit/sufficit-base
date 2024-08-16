using System;
using System.Collections;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// 
    /// </summary>
    public class BillingSearchParameters
    {
        [JsonPropertyName("contextid")]
        public Guid? ContextId { get; set; }

        [JsonPropertyName("start")]
        public DateTime? Start { get; set; }

        [JsonPropertyName("end")]
        public DateTime? End { get; set; }

        [JsonPropertyName("uniqueid")]
        public string? UniqueId { get; set; }

        [JsonPropertyName("extension")]
        public TextFilter? Extension { get; set; }
    }
}
