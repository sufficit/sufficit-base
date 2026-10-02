using System;

namespace Sufficit.Finance
{
    /// <summary>One authoritative activation or allocated payment event, with reversals as of observation.</summary>
    public class CallCreditContribution
    {
        /// <summary>Stable identity of the source event or payment allocation, used for deduplication.</summary>
        public Guid Id { get; set; }
        public Guid ContextId { get; set; }
        /// <summary>Activation time or payment confirmation time, never invoice due date.</summary>
        public DateTime OccurredAtUtc { get; set; }
        /// <summary>Explicit source service recurrence; null means the source is not classified.</summary>
        public bool? ServiceIsRecurring { get; set; }
        public CallCreditContributionTrigger Trigger { get; set; }
        /// <summary>Activated service credit or confirmed payment portion allocated to eligible credit.</summary>
        public decimal Amount { get; set; }
        public decimal ReversedAmount { get; set; }
        public CallCreditContributionKind Kind { get; set; }
    }
}
