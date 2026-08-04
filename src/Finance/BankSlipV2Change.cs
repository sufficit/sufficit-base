using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Lightweight, non-sensitive notification that a bank slip aggregate changed.
    /// Clients must fetch the authorized resource from the API for full details.
    /// </summary>
    public sealed class BankSlipV2Change : EventArgs
    {
        public Guid ContextId { get; set; }
        public Guid BankSlipId { get; set; }
        public BankSlipStatus Status { get; set; }
        public string Provider { get; set; } = string.Empty;
        public DateTime UpdatedAtUtc { get; set; }
        public long Version { get; set; }
    }
}
