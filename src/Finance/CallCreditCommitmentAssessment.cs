using System;

namespace Sufficit.Finance
{
    /// <summary>Read-only assessment. An incomplete result cannot authorize a tariff reset.</summary>
    public class CallCreditCommitmentAssessment
    {
        public Guid ContextId { get; set; }
        public DateTime? CycleStartUtc { get; set; }
        public DateTime? CycleEndUtc { get; set; }
        public decimal RequiredAmount { get; set; }
        public decimal? EligibleAmount { get; set; }
        public decimal? MissingAmount { get; set; }
        public CallCreditCommitmentStatus Status { get; set; }
    }
}
