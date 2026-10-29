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

        /// <summary>
        /// Provider payment method (e.g. Asaas billingType PIX, BOLETO,
        /// CREDIT_CARD, TRANSFER). Filled only by providers whose webhook
        /// carries every payment of the account, so an unmatched paid event
        /// can be recognised as a receipt no Sufficit system owns.
        /// </summary>
        public string? PaymentMethod { get; set; }

        /// <summary>Provider customer identifier of the payer.</summary>
        public string? PayerReference { get; set; }

        /// <summary>Free-text description attached by the provider or issuer.</summary>
        public string? Description { get; set; }

        /// <summary>
        /// Provider checkout session that originated the payment; such
        /// payments belong to the checkout even without an external reference.
        /// </summary>
        public string? CheckoutSessionId { get; set; }

        /// <summary>Public receipt or invoice page of the payment.</summary>
        public string? ReceiptUrl { get; set; }

        public string Payload { get; set; } = "{}";
    }
}
