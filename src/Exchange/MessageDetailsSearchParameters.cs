using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange
{
    public class MessageDetailsSearchParameters : ILimit
    {
        /// <summary>
        ///     Default limit parameter
        /// </summary>
        public const uint LIMIT = 100;

        [JsonPropertyName("modelid")]
        public Guid? ModelId { get; set; }

        [JsonPropertyName("contextid")]
        public Guid? ContextId { get; set; }

        [JsonPropertyName("referenceid")]
        public Guid? ReferenceId { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        [JsonPropertyName("limit")]
        public uint? Limit { get; set; } = LIMIT;

        [JsonPropertyName("timestamp")]
        public DateTimeMatch? Timestamp { get; set; }
    }
}
