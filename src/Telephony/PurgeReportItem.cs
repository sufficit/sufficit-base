using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Represents the result of a purge operation for a telephony resource type.
    /// </summary>
    /// <remarks>
    /// <para>
    ///     <strong>Generic DTO — do NOT add subsystem-specific fields here.</strong>
    ///     This class is shared across all telephony purge operations. Subsystem-specific
    ///     data belongs in the subsystem's own project or should be expressed through the
    ///     existing generic properties.
    /// </para>
    /// </remarks>
    public class PurgeReportItem
    {
        /// <summary>
        ///     Logical resource type that was purged (e.g. table name, entity set, log category).
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        /// <summary>
        ///     How many records were affected by the purge.
        /// </summary>
        [JsonPropertyName("count")]
        public uint Count { get; set; }

        /// <summary>
        ///     Optional informational messages produced by the purge operation
        ///     (e.g. key column names, prefix filters applied).
        /// </summary>
        [JsonPropertyName("messages")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string>? Messages { get; set; }

        /// <summary>
        ///     Captured exception for internal diagnostics. Not serialized.
        /// </summary>
        [JsonIgnore]
        public Exception? Exception { get; set; }
    }
}
