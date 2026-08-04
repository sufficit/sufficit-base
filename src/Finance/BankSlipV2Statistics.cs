using System;
using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>
    /// Represents the compact operational summary consumed by administration surfaces.
    /// Raw time-series data remains in the configured metrics provider.
    /// </summary>
    public class BankSlipV2Statistics
    {
        public DateTime WindowStartUtc { get; set; }
        public DateTime WindowEndUtc { get; set; }
        public int Total { get; set; }
        public int Requested { get; set; }
        public int Processing { get; set; }
        public int Ready { get; set; }
        public int Paid { get; set; }
        public int Canceled { get; set; }
        public int Failed { get; set; }
        public int ReconciliationPending { get; set; }
        public int CancellationPending { get; set; }
        public int OperationalAlerts { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalIssuanceCost { get; set; }
        public double? IssuanceP95Seconds { get; set; }
        public double? IssuanceP99Seconds { get; set; }
        public IReadOnlyList<BankSlipV2ProviderStatistics> Providers { get; set; }
            = Array.Empty<BankSlipV2ProviderStatistics>();
    }
}
