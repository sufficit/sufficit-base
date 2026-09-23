using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Operational provider observation, not the accounting date. A paid event
    /// may occur after the civil day reported in the bank receipt.
    /// </summary>
    public sealed class RecentBankSlipActivity
    {
        public Guid BankSlipId { get; set; }
        public Guid ContextId { get; set; }
        public string? ProviderChargeId { get; set; }
        public DateTime EventAtUtc { get; set; }

        /// <summary>
        /// Civil day the bank reported receiving the payment (the accounting
        /// date used by the ledger). Null while the payment is pending.
        /// </summary>
        public DateTime? PaidAtUtc { get; set; }

        public DateTime? ReceivedByBankAtUtc { get; set; }
        public decimal Value { get; set; }
        public bool PendingConfirmation { get; set; }
    }
}
