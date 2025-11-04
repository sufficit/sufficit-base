using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.AI
{
    public class AIProcessSearchParameters : SearchParameters
    {
        [JsonPropertyName("key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TextFilter? Key { get; set; }

        [JsonPropertyName("system")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? System { get; set; }

        [JsonPropertyName("method")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TextFilter? Method { get; set; }

        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Status { get; set; }

        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTimeRangeNew? Timestamp { get; set; }
    }
}