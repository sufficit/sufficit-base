using System;

namespace Sufficit.Finance
{
    /// <summary>Explicit customer agreement; recharge amounts never create agreements implicitly.</summary>
    public class CallCreditCommitmentPolicy
    {
        public Guid ContextId { get; set; }
        public DateTime AnniversaryUtc { get; set; }
        public uint CycleMonths { get; set; } = 1;
        public decimal MinimumAmount { get; set; }
        /// <summary>Eligible toll-free credit shares the commitment unless explicitly disabled.</summary>
        public bool IncludeTollFreeCredit { get; set; } = true;
    }
}
