using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    /// Result of a manual dialout trunk usage reset performed against one local FastAGI process.
    /// </summary>
    /// <remarks>
    /// Scope: operational runtime payload shared between FastAGI HTTP hosts and their internal clients.
    /// The reset only reflects one process-local in-memory counter state.
    /// </remarks>
    public sealed class DialOutUsageResetResponse
    {
        /// <summary>
        /// Customer context identifier whose trunk usage was reset.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        /// Trunk title used as the usage counter key, for example <c>SINGLE</c>.
        /// </summary>
        public string Trunk { get; set; } = string.Empty;

        /// <summary>
        /// Number of in-memory counter entries removed by the reset.
        /// </summary>
        public int RemovedCount { get; set; }

        /// <summary>
        /// Remaining number of alive entries for the same context and trunk after the reset.
        /// </summary>
        public int RemainingCount { get; set; }

        /// <summary>
        /// UTC timestamp when the reset completed.
        /// </summary>
        public DateTimeOffset ResetAtUtc { get; set; }
    }
}
