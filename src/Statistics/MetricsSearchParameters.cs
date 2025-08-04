using System;
using System.Text.Json.Serialization;

namespace Sufficit.Statistics
{
    /// <summary>
    /// Search parameters for metrics queries
    /// </summary>
    public class MetricsSearchParameters
    {
        /// <summary>
        /// Filter by category (required for most searches)
        /// </summary>
        [JsonPropertyName("category")]
        public TextFilter? Category { get; set; }

        /// <summary>
        /// Filter by metric name
        /// </summary>
        [JsonPropertyName("name")]
        public TextFilter? Name { get; set; }

        /// <summary>
        /// Filter by period (daily, weekly, monthly, etc.)
        /// </summary>
        [JsonPropertyName("period")]
        public TextFilter? Period { get; set; }

        /// <summary>
        /// Filter by subtype (channel, source, destination, etc.)
        /// </summary>
        [JsonPropertyName("subtype")]
        public TextFilter? Subtype { get; set; }

        /// <summary>
        /// Date range filtering for metric dates
        /// </summary>
        [JsonPropertyName("date")]
        public DateOnlyRange? Date { get; set; }

        /// <summary>
        /// Filter by metric type (counter, gauge, etc.)
        /// </summary>
        [JsonPropertyName("type")]
        public TextFilter? Type { get; set; }

        /// <summary>
        /// Filter by extra information stored in JSON format
        /// </summary>
        [JsonPropertyName("extra")]
        public TextFilter? Extra { get; set; }

        /// <summary>
        /// Filter by context identifier for client-specific metrics
        /// </summary>
        [JsonPropertyName("contextid")]
        public Guid? ContextId { get; set; }

        /// <summary>
        /// Value range filtering for metric values
        /// </summary>
        [JsonPropertyName("value")]
        public DecimalRange? Value { get; set; }

        /// <summary>
        /// Include only non-expired metrics
        /// </summary>
        [JsonPropertyName("onlyactive")]
        public bool OnlyActive { get; set; } = true;

        /// <summary>
        /// Timestamp range filtering for when metrics were created/updated
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTimeRangeNew? Timestamp { get; set; }

        /// <summary>
        /// Maximum number of results to return
        /// </summary>
        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Number of results to skip (for pagination)
        /// </summary>
        [JsonPropertyName("offset")]
        public int? Offset { get; set; }

        /// <summary>
        /// Order by field (date, value, timestamp, etc.)
        /// </summary>
        [JsonPropertyName("orderby")]
        public string? OrderBy { get; set; }

        /// <summary>
        /// Sort direction (ascending/descending)
        /// </summary>
        [JsonPropertyName("descending")]
        public bool Descending { get; set; } = false;
    }
}
