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
    }
}
