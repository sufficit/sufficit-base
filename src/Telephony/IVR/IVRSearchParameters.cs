using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.IVR
{
    /// <summary>
    /// Interactive Voice Response search parameters
    /// </summary>
    public class IVRSearchParameters : ILimit
    {
        /// <summary>
        /// Default name for IVRMenu Id parameter
        /// </summary>
        public const string IVRID = "ivrid";

        /// <summary>IVRMenu unique id or empty for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonPropertyName(IVRID)]
        public Guid? IVRId { get; set; }

        /// <summary>IVRMenu unique id or empty for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? ContextId { get; set; }

        /// <summary>
        /// IVRMenu title, can be partial or full match
        /// </summary>
        public TextFilter? Title { get; set; }

        /// <summary>
        /// Extension to be used when direct dialing to an IVRMenu
        /// </summary>
        public string? Extension { get; set; }

        /// <summary>
        /// FreePBX identifier, if any
        /// Used to link with FreePBX system, if any
        /// </summary>
        public int? FPBXId { get; set; }

        /// <summary>
        /// Timestamp filters used by incremental IVRMenu refreshes.
        /// Current runtime sync uses <c>UpdatedAtUtc</c> and <c>DeletedAtUtc</c>
        /// so memory stores can merge deltas and evict tombstones.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimestampFilter? Timestamp { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        public uint? Limit { get; set; }
    }
}
