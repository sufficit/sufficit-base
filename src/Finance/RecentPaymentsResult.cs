using System;
using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>
    /// Result envelope for the recent payments operational view.
    /// </summary>
    public sealed class RecentPaymentsResult
    {
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime GeneratedAtUtc { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime StartUtc { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime EndUtc { get; set; }

        /// <summary>Number of items returned in this page.</summary>
        public int Count { get; set; }

        /// <summary>Number of matching payments across all pages.</summary>
        public int TotalCount { get; set; }

        /// <summary>Sum of all matching payments, before paging.</summary>
        public decimal TotalValue { get; set; }

        /// <summary>
        /// Matching payments already reported by the bank while the provider
        /// still has not confirmed them. They are included in
        /// <see cref="TotalCount"/> and <see cref="TotalValue"/>.
        /// </summary>
        public int PendingConfirmationCount { get; set; }

        /// <summary>Sum of the pending-confirmation payments included in <see cref="TotalValue"/>.</summary>
        public decimal PendingConfirmationValue { get; set; }

        public List<RecentPayment> Items { get; set; } = new();
    }
}
