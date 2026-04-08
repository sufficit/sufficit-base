using System;
using System.Text.Json.Serialization;

namespace Sufficit
{
    /// <summary>
    ///     Logical UTC timestamp filters used by provider search contracts.
    ///     Each property is an inclusive lower bound for that mutation type.
    ///     Physical column names stay mapped inside EF and must not leak here.
    /// </summary>
    public sealed class TimestampFilter
    {
        /// <summary>
        ///     Include rows created on or after this UTC instant.
        /// </summary>
        [JsonPropertyName("created_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? CreatedAtUtc { get; set; }

        /// <summary>
        ///     Include rows whose last active mutation happened on or after this UTC instant.
        ///     Providers may fall back to <c>CreatedAtUtc</c> when the row has never been updated.
        /// </summary>
        [JsonPropertyName("updated_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? UpdatedAtUtc { get; set; }

        /// <summary>
        ///     Include rows soft-deleted on or after this UTC instant.
        ///     Supplying this filter also signals that tombstones should be returned.
        /// </summary>
        [JsonPropertyName("deleted_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? DeletedAtUtc { get; set; }
    }
}
