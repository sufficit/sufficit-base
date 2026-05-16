using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    /// Current in-memory usage counter snapshot for one dialout trunk and context.
    /// </summary>
    /// <remarks>
    /// Scope: operational runtime payload shared between FastAGI HTTP hosts and their internal clients.
    /// It describes the current process-local counter state and is not intended for persistence.
    /// </remarks>
    public sealed class DialOutUsageSnapshot
    {
        /// <summary>
        /// Customer context identifier whose trunk usage is being inspected.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        /// Trunk title used as the usage counter key, for example <c>SINGLE</c>.
        /// </summary>
        public string Trunk { get; set; } = string.Empty;

        /// <summary>
        /// Current number of alive entries found in the process-local usage cache.
        /// </summary>
        public int CurrentCount { get; set; }

        /// <summary>
        /// UTC timestamp when the snapshot was produced.
        /// </summary>
        public DateTimeOffset CheckedAtUtc { get; set; }
    }
}
