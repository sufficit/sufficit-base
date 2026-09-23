using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// A bank receipt observed on a bank slip whose payment the provider has
    /// not confirmed yet (e.g. Efí "identified"). Pure operational evidence:
    /// the financial ledger stays untouched until confirmation.
    /// </summary>
    public sealed class PendingBankSlipReceipt
    {
        public Guid BankSlipId { get; set; }

        public Guid ContextId { get; set; }

        public string Provider { get; set; } = string.Empty;

        public string? ProviderChargeId { get; set; }

        public decimal Value { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime ReceivedByBankAtUtc { get; set; }
    }
}
