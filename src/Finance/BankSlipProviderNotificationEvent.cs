using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// One provider status transition obtained from a notification token.
    /// </summary>
    public sealed class BankSlipProviderNotificationEvent
    {
        public string EventId { get; set; } = string.Empty;
        public string? ChargeId { get; set; }
        public string? CustomId { get; set; }
        public string? EventType { get; set; }
        public string? ProviderStatus { get; set; }
        public BankSlipStatus? Status { get; set; }
        public DateTime? EventAtUtc { get; set; }
        public DateTime? PaidAtUtc { get; set; }

        /// <summary>
        /// Bank receipt day reported alongside a non-paid status (e.g. Efí
        /// "identified"). It is evidence only: the payment stays unconfirmed
        /// and the ledger untouched until the provider confirms.
        /// </summary>
        public DateTime? ReceivedByBankAtUtc { get; set; }

        public decimal? Value { get; set; }
        public string Payload { get; set; } = "{}";
    }
}
