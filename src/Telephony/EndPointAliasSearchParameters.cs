using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Search contract for legacy endpoint alias rows.
    ///     The compatibility projection refreshes aliases independently from
    ///     the endpoint table, so aliases need their own incremental window.
    /// </summary>
    public sealed class EndPointAliasSearchParameters
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? EndPointId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ContextId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Alias { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; }

        /// <summary>
        /// Timestamp filters used by incremental alias refreshes.
        /// Compatibility sync currently relies on <c>UpdatedAtUtc</c> plus
        /// <c>DeletedAtUtc</c> so alias tombstones can evict stale memory rows.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimestampFilter? Timestamp { get; set; }
    }
}
