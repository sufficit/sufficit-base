using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// A paid provider charge that no Sufficit system owns (Pix sent to the
    /// account key, TED, payment link or a charge created in the provider
    /// panel). Kept without payload expiry until someone treats it.
    /// </summary>
    public sealed class BankSlipUnownedReceiptView
    {
        public Guid Id { get; set; }
        public string Provider { get; set; } = string.Empty;
        public string ProviderChargeId { get; set; } = string.Empty;
        public string? PaymentMethod { get; set; }
        public decimal? Value { get; set; }
        public DateTime? PaidAtUtc { get; set; }
        public string? PayerReference { get; set; }
        public string? Description { get; set; }
        public string? ExternalReference { get; set; }
        public string? ProviderStatus { get; set; }
        public string? ReceiptUrl { get; set; }
        public DateTime FirstSeenAtUtc { get; set; }
        public DateTime LastEventAtUtc { get; set; }
        public BankSlipUnownedReceiptState State { get; set; }
        public string? ResolutionNote { get; set; }
        public Guid? ResolvedBy { get; set; }
        public DateTime? ResolvedAtUtc { get; set; }
    }
}
