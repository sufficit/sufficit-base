using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Logging
{
    /// <summary>
    /// Log Base server and time properties
    /// </summary>
    /// <remarks>*shared with message details record</remarks>
    public abstract class LogBaseServerAndTime
    {
        /// <summary>
        /// Title for the server that processed this event
        /// </summary>
        /// <value>Environment.MachineName</value>
        [StringLength(100)]
        [JsonPropertyName("server")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Server { get; set; } = Environment.MachineName;

        /// <summary>
        ///     Time of duration of this process, for track low or long process
        /// </summary>
        [JsonPropertyName("duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual TimeSpan? Duration { get; set; }

        /// <summary>
        ///     Date/Time that the event first occurs
        /// </summary>
        [JsonPropertyName("timestamp")]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        ///     Date/Time that this record should be not important/valid anymore
        /// </summary>
        [JsonPropertyName("expiration")]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Expiration { get; set; }
    }
}
