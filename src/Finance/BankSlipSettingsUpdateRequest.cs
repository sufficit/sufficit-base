using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>
    /// Represents a tenant-scoped bank slip settings update.
    /// </summary>
    public class BankSlipSettingsUpdateRequest
    {
        public decimal MinimumValue { get; set; }
        public decimal MaximumValue { get; set; }
        /// <summary>Allow mouse-wheel changes to the issuance amount field.</summary>
        public bool AmountChangeOnWheel { get; set; }
        /// <summary>Allow ArrowUp/ArrowDown changes independently of mouse-wheel changes.</summary>
        public bool AmountChangeOnArrowKeys { get; set; } = true;
        /// <summary>Symmetric wheel increment in BRL, independent of monetary input precision.</summary>
        public decimal AmountWheelStep { get; set; } = 1m;
        public string DefaultProvider { get; set; } = BankSlipProviderCodes.Efi;
        public short PayerSnapshotRetentionYears { get; set; } = 5;
        public long? Version { get; set; }
        public IReadOnlyList<BankSlipProviderSettingsUpdate> Providers { get; set; }
            = System.Array.Empty<BankSlipProviderSettingsUpdate>();
    }
}
