using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Charts
{
    public class Record
    {
        [JsonPropertyName("chartid")]
        public Guid ChartId { get; set; }

        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; } = default!;

        [JsonPropertyName("value")]
        public string Value { get; set; } = default!;

        [JsonPropertyName("expiration")]
        public DateTime Expiration { get; set; }
    }
}
