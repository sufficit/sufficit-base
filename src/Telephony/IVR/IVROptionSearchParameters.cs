using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.IVR
{
    /// <summary>
    /// IVRMenu option search parameters.
    /// </summary>
    public class IVROptionSearchParameters : ILimit
    {
        [JsonPropertyName("ivrid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? IVRId { get; set; }

        [JsonPropertyName("digits")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TextFilter? Digits { get; set; }

        /// <summary>
        /// Timestamp filters used by incremental IVRMenu option refreshes.
        /// Current runtime sync uses <c>UpdatedAtUtc</c> and <c>DeletedAtUtc</c>
        /// so memory stores can merge deltas and evict tombstones.
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TimestampFilter? Timestamp { get; set; }

        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public uint? Limit { get; set; }
    }
}
