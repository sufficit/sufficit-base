using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class AnsweredReportItem
    {
        [JsonPropertyName("date")]
#if NET7_0_OR_GREATER
        public DateOnly Date { get; set; }
#else
        public DateTime Date { get; set; }
#endif

        [JsonPropertyName("extension")]
        public string Extension { get; set; } = string.Empty;

        [JsonPropertyName("count")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public uint Count { get; set; }

        [JsonPropertyName("items")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<object>? Items { get; set; }
    }
}
