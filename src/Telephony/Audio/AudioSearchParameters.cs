using System;
using Sufficit;

namespace Sufficit.Telephony.Audio
{
    /// <summary>
    /// Telephony audio placeholder search parameters.
    /// </summary>
    public class AudioSearchParameters : IIncrementalTrackingSearchParameters
    {
        /// <summary>Audio placeholder unique id or <see langword="null"/> for any placeholder.</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? AudioId { get; set; }

        /// <summary>Tenant/context unique id or <see langword="null"/> for any context.</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? ContextId { get; set; }

        /// <summary>Exact placeholder title or <see langword="null"/> for any title.</summary>
        public string? Title { get; set; }

        /// <inheritdoc cref="IIncrementalTrackingSearchParameters.Timestamp"/>
        public TimestampFilter? Timestamp { get; set; }

        /// <inheritdoc cref="IIncrementalTrackingSearchParameters.Deleted"/>
        public bool? Deleted { get; set; }
    }
}
