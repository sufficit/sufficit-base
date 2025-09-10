using System;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange
{
    /// <summary>
    /// Search parameters for Message Template queries
    /// Follows Sufficit search pattern with single Search method
    /// </summary>
    public class MessageTemplateSearchParameters : SearchParameters
    {
        /// <summary>
        /// Filter by template title (business identifier)
        /// </summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextFilter? Title { get; set; }

        /// <summary>
        /// Filter by template description (human-readable name)
        /// </summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextFilter? Description { get; set; }

        /// <summary>
        /// Filter by approval status
        /// </summary>
        [JsonPropertyName("approved")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Approved { get; set; }

        /// <summary>
        /// Filter by context ID
        /// </summary>
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ContextId { get; set; }

        /// <summary>
        /// Filter by timestamp range
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTimeRangeNew? Timestamp { get; set; }

        /// <summary>
        /// Filter by content (subject or body)
        /// </summary>
        [JsonPropertyName("content")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextFilter? Content { get; set; }
    }
}
