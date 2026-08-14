namespace Sufficit.Finance
{
    /// <summary>
    /// Represents provider-level aggregates for the bank slip operational summary.
    /// </summary>
    public class BankSlipProviderStatistics
    {
        public string Provider { get; set; } = string.Empty;
        public int Total { get; set; }
        public int Ready { get; set; }
        public int Failed { get; set; }
        public int ReconciliationPending { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalIssuanceCost { get; set; }
        public double? AverageIssuanceSeconds { get; set; }
    }
}
