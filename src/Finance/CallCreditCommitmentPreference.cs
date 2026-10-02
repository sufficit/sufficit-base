using System;

namespace Sufficit.Finance
{
    /// <summary>Customer-wide eligibility preference, independent of balances and recurring invoices.</summary>
    public class CallCreditCommitmentPreference
    {
        public Guid ContextId { get; set; }
        public bool IncludeTollFreeCredit { get; set; } = true;
    }
}
