using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>
    /// Provider-neutral notification history returned for one callback token.
    /// </summary>
    public sealed class BankSlipProviderNotificationBatch
    {
        public string ProviderCode { get; set; } = string.Empty;
        public IReadOnlyList<BankSlipProviderNotificationEvent> Events { get; set; }
            = new List<BankSlipProviderNotificationEvent>();
    }
}
