using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sufficit.Statistics
{
    /// <summary>
    /// Statistics metrics entity for storing calculated metrics by background jobs
    /// </summary>
    [Table("stat_metrics")]
    public class Metric
    {
        /// <summary>
        /// Metric category - ex: exchange_messages, telephony_calls
        /// </summary>
        [Required]
        [StringLength(20)]
        [Column("category", TypeName = "CHAR(20)")]
        public string Category { get; set; } = default!;

        /// <summary>
        /// Specific metric name - ex: total_count, success_rate, avg_processing_time
        /// </summary>
        [Required]
        [StringLength(200)]
        [Column("metric", TypeName = "VARCHAR(200)")]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Numeric metric value with high decimal precision
        /// </summary>
        [Required]
        [Column("value", TypeName = "DECIMAL(18,6)")]
        public decimal Value { get; set; }

        /// <summary>
        /// Value type - ex: count, rate, average, percentage
        /// </summary>
        [Required]
        [StringLength(10)]
        [Column("type", TypeName = "CHAR(10)")]
        public string Type { get; set; } = default!;

        /// <summary>
        /// Aggregation period - ex: daily, hourly, weekly, monthly
        /// </summary>
        [Required]
        [StringLength(10)]
        [Column("period", TypeName = "CHAR(10)")]
        public string Period { get; set; } = default!;

        /// <summary>
        /// UTC timestamp when metric was related, truncate by period
        /// </summary>
        [Required]
        [Column("timestamp", TypeName = "DATETIME(6)")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Category-specific subtype - ex: whatsapp (messages), inbound (calls), website (sales), default (generic)
        /// </summary>
        [Required]
        [StringLength(20)]
        [Column("subtype", TypeName = "CHAR(20)")]
        public string Subtype { get; set; } = "default";

        /// <summary>
        /// Optional additional field for specific filters
        /// </summary>
        [StringLength(50)]
        [Column("extra", TypeName = "VARCHAR(50)")]
        public string? Extra { get; set; }

        /// <summary>
        /// Context identifier for client-specific metrics (Guid.Empty for global metrics)
        /// </summary>
        [Required]
        [Column("contextid", TypeName = "BINARY(16)")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// UTC date/time when this record should be removed by automatic cleanup
        /// </summary>
        [Required]
        [Column("expiration", TypeName = "DATETIME(6)")]
        public DateTime Expiration { get; set; }
    }
}
