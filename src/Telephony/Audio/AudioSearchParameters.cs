using System;

namespace Sufficit.Telephony.Audio
{
    /// <summary>
    /// Telephony audio placeholder search parameters.
    /// </summary>
    public class AudioSearchParameters
    {
        /// <summary>Audio placeholder unique id or <see langword="null"/> for any placeholder.</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? AudioId { get; set; }

        /// <summary>Tenant/context unique id or <see langword="null"/> for any context.</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? ContextId { get; set; }

        /// <summary>Exact placeholder title or <see langword="null"/> for any title.</summary>
        public string? Title { get; set; }

        /// <summary>
        /// Logical incremental synchronization window, not a physical schema contract.
        /// Use <c>UpdatedAtUtc</c> for active mutations and <c>DeletedAtUtc</c> for tombstones.
        /// </summary>
        public TimestampFilter? Timestamp { get; set; }
    }
}
