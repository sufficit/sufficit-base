using System;
using System.Collections.Generic;

namespace Sufficit.Statistics
{
    /// <summary>
    /// Universal metrics query parameters compatible with InfluxDB, Prometheus, and Entity Framework
    /// Designed for maximum compatibility and performance across different providers
    /// </summary>
    public class MetricsSearchParameters
    {
        /// <summary>
        /// Measurement name filter (supports contains, exact match, etc.)
        /// Examples: "calls", "messages", "sales"
        /// Compatible with InfluxDB measurements, Prometheus metric names, and EF tables
        /// </summary>
        public TextFilter? Measurement { get; set; }

        /// <summary>
        /// Timestamp filter for the query using our standard DateTimeRangeNew
        /// Filters by the main timestamp property when the metric was recorded
        /// Universal: works with all time-series databases
        /// </summary>
        public DateTimeRangeNew? Timestamp { get; set; }

        /// <summary>
        /// Tags for filtering (key-value pairs)
        /// Examples: ["category": "telephony", "channel": "sip", "direction": "inbound"]
        /// Universal: InfluxDB tags, Prometheus labels, EF JSON fields
        /// </summary>
        public Dictionary<string, string> Tags { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Field names to return (if empty, returns all fields)
        /// Examples: ["total_count", "success_rate", "average_duration"]
        /// Universal: InfluxDB fields, Prometheus values, EF properties
        /// </summary>
        public List<string> Fields { get; set; } = new List<string>();

        /// <summary>
        /// Maximum number of results to return
        /// Universal: supported by all providers
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Number of results to skip (for pagination)
        /// Universal: supported by all providers
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Group by tags (for aggregation)
        /// Examples: ["channel", "direction"] will group results by these tags
        /// Universal: GROUP BY in SQL, GROUP BY in InfluxDB, group_by in Prometheus
        /// </summary>
        public List<string> GroupBy { get; set; } = new List<string>();

        /// <summary>
        /// Sort order (field name and direction)
        /// Examples: [{"timestamp": "desc"}, {"total_count": "asc"}]
        /// Universal: ORDER BY in SQL, sort in InfluxDB, sort_desc in Prometheus
        /// </summary>
        public Dictionary<string, string> OrderBy { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Time bucket for aggregation (like "1h", "1d", "1w")
        /// Universal: time buckets work in InfluxDB, Prometheus ranges, EF grouping
        /// </summary>
        public string? TimeBucket { get; set; }

        /// <summary>
        /// Aggregation functions to apply
        /// Examples: ["count", "sum", "avg", "min", "max"]
        /// Universal: same functions exist in all providers
        /// </summary>
        public List<string> Aggregations { get; set; } = new List<string>();
    }
}
