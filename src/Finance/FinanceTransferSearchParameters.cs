using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    /// <summary>
    ///     Filters used by administrative financial transfer searches.
    /// </summary>
    public sealed class FinanceTransferSearchParameters : ILimit
    {
        public Guid? SourceId { get; set; }

        public Guid? DestinationId { get; set; }

        public Guid? UserId { get; set; }

        /// <summary>
        ///     Filters the accounting timestamp by a UTC date and time range.
        /// </summary>
        public DateTimeRange? Timestamp { get; set; }

        /// <summary>
        ///     Filters the transfer description by exact or partial text matching.
        /// </summary>
        public TextFilter? Description { get; set; }

        public bool? Active { get; set; }

        [JsonPropertyName("limit")]
        [DefaultValue((uint)30)]
        public uint? Limit { get; set; } = 30;
    }
}
