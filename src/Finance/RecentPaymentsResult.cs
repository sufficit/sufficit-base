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

        public int Count { get; set; }

        public decimal TotalValue { get; set; }

        public List<RecentPayment> Items { get; set; } = new();
    }
}
