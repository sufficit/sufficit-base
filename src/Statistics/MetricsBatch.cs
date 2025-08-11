using System;
using System.Collections.Generic;

namespace Sufficit.Statistics
{
    /// <summary>
    /// Represents a batch of metrics to be written in a single operation
    /// </summary>
    public class MetricsBatch
    {
        /// <summary>
        /// Measurement name for this batch
        /// </summary>
        public string Measurement { get; set; } = default!;

        /// <summary>
        /// Timestamp for all metrics in this batch
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Tags applied to all metrics in this batch (for filtering and grouping)
        /// </summary>
        public Dictionary<string, string> Tags { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Field values for this batch (metric name -> value)
        /// </summary>
        public Dictionary<string, object> Fields { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Add a tag to this batch
        /// </summary>
        /// <param name="key">Tag key</param>
        /// <param name="value">Tag value</param>
        /// <returns>This batch for fluent configuration</returns>
        public MetricsBatch AddTag(string key, string value)
        {
            Tags[key] = value;
            return this;
        }

        /// <summary>
        /// Add a field to this batch
        /// </summary>
        /// <param name="name">Field name</param>
        /// <param name="value">Field value</param>
        /// <returns>This batch for fluent configuration</returns>
        public MetricsBatch AddField(string name, object value)
        {
            Fields[name] = value;
            return this;
        }
    }
}
