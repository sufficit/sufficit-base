namespace Sufficit.Finance
{
    /// <summary>
    /// Represents an administrative update for one tenant provider.
    /// </summary>
    public class BankSlipV2ProviderSettingsUpdate
    {
        public string Provider { get; set; } = string.Empty;
        public bool Enabled { get; set; }
        public short Priority { get; set; }
        public decimal? MinimumValue { get; set; }
        public decimal? MaximumValue { get; set; }
        public decimal IssuanceCost { get; set; }
        public bool IncludePayerEmail { get; set; }
        public string Environment { get; set; } = "sandbox";
        public string CredentialReference { get; set; } = string.Empty;
        public long? Version { get; set; }
    }
}
