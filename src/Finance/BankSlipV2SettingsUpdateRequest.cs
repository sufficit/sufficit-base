using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>
    /// Represents a tenant-scoped bank slip settings update.
    /// </summary>
    public class BankSlipV2SettingsUpdateRequest
    {
        public decimal MinimumValue { get; set; }
        public decimal MaximumValue { get; set; }
        public string DefaultProvider { get; set; } = BankSlipProviderCodes.Efi;
        public short PayerSnapshotRetentionYears { get; set; } = 5;
        public long? Version { get; set; }
        public IReadOnlyList<BankSlipV2ProviderSettingsUpdate> Providers { get; set; }
            = System.Array.Empty<BankSlipV2ProviderSettingsUpdate>();
    }
}
