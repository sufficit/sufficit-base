using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>
    /// Represents bank slip administration settings for the active tenant.
    /// </summary>
    public class BankSlipSettingsView
    {
        public decimal MinimumValue { get; set; }
        public decimal MaximumValue { get; set; }
        public string Currency { get; set; } = "BRL";
        public string DefaultProvider { get; set; } = BankSlipProviderCodes.Efi;
        public short PayerSnapshotRetentionYears { get; set; }
        public long Version { get; set; }
        public IReadOnlyList<BankSlipProviderSettingsView> Providers { get; set; }
            = System.Array.Empty<BankSlipProviderSettingsView>();
    }
}
