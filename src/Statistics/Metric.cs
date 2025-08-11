using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sufficit.Statistics
{
    /// <summary>
    /// Base metric class representing a time-series data point (InfluxDB-style)
    /// Serializable for multi-target framework support (.NET Standard 2.0, .NET 6, 7, 8, 9)
    /// </summary>
    [Serializable]
    public class Metric
    {
        /// <summary>
        /// Timestamp when the metric was recorded (UTC)
        /// </summary>
        [Required]
        [JsonPropertyName("timestamp")]
        [JsonPropertyOrder(0)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Name of the measurement (e.g., "total_calls", "cpu_usage", "response_time")
        /// </summary>
        [Required]
        [MaxLength(255)]
        [JsonPropertyName("measurement")]
        [JsonPropertyOrder(0)]
        public string Measurement { get; set; } = default!;


        /// <summary>
        /// Values associated with the metric
        /// </summary>
        [JsonPropertyName("fields")]
        [JsonPropertyOrder(1)]
        public Dictionary<string, object> Fields { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Dictionary of tags for flexible metadata and filtering
        /// </summary>
        [JsonPropertyName("tags")]
        [JsonPropertyOrder(1)]
        public Dictionary<string, string> Tags { get; set; } = new Dictionary<string, string>();
    }
}
