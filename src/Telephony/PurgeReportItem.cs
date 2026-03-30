using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Represents the result of a purge operation for a telephony resource type.
    /// </summary>
    public class PurgeReportItem
    {
        /// <summary>
        /// Gets or sets the logical resource type that was purged.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        /// <summary>
        /// Gets or sets how many records were affected by the purge.
        /// </summary>
        [JsonPropertyName("count")]
        public uint Count { get; set; }

        /// <summary>
        /// Gets or sets optional informational messages produced by the purge operation.
        /// </summary>
        [JsonPropertyName("messages")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string>? Messages { get; set; }

        /// <summary>
        /// Gets or sets the captured exception for internal diagnostics.
        /// </summary>
        [JsonIgnore]
        public Exception? Exception { get; set; }
    }
}
