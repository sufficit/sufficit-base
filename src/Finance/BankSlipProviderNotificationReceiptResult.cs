using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Result of durably accepting a provider callback.
    /// </summary>
    public sealed class BankSlipProviderNotificationReceiptResult
    {
        public bool Accepted { get; set; }
        public Guid? ReceiptId { get; set; }
        public BankSlipProviderNotificationReceiptStatus Status { get; set; }
    }

    public enum BankSlipProviderNotificationReceiptStatus : byte
    {
        Rejected = 0,
        Accepted = 1,
        Unauthorized = 2,
        InvalidPayload = 3,
        ProviderNotConfigured = 4
    }
}
