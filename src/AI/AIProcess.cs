using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.AI
{
    public class AIProcess
    {
        [JsonPropertyName("key")]
        [StringLength(100)]
        public string Key { get; set; } = default!;

        /// <summary>
        ///     Timestamp of the process creation or last update
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonPropertyName("system")]
        public string System { get; set; } = default!;

        [JsonPropertyName("method")]
        public string Method { get; set; } = default!;

        [JsonPropertyName("content")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual string? Content { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = default!;
    }
}