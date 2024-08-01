using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Notification
{
    public class Subscription
    {
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ContextId { get; set; }

        [JsonPropertyName("eventid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid EventId { get; set; }

        /// <summary>
        ///     Optional key
        /// </summary>
        /// <remarks>*soon it will be nullable</remarks>
        [JsonPropertyName("key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Key { get; set; } = string.Empty;

        [JsonPropertyName("contactid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ContactId { get; set; }

        /// <summary>
        ///     Last update time
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Timestamp { get; set; }
    }
}
