namespace Sufficit.Finance
{
    /// <summary>
    /// Represents tenant-scoped configuration for one bank slip provider.
    /// </summary>
    public class BankSlipProviderSettingsView
    {
        public string Provider { get; set; } = string.Empty;
        public bool Enabled { get; set; }
        public short Priority { get; set; }
        public decimal? MinimumValue { get; set; }
        public decimal? MaximumValue { get; set; }
        public decimal IssuanceCost { get; set; }
        /// <summary>Provider tariff per received payment, applied to each payment confirmed from now on; zero records no cost.</summary>
        public decimal ReceiptCost { get; set; }
        /// <summary>Provider account that pays the tariff; required when <see cref="ReceiptCost"/> is set.</summary>
        public string? ProviderAccount { get; set; }
        public bool IncludePayerEmail { get; set; }
        public string Environment { get; set; } = "sandbox";
        public string CredentialReference { get; set; } = string.Empty;
        public long Version { get; set; }
    }
}
