using System;

namespace Sufficit.Finance
{
    /// <summary>Review-only detection snapshot, never an active billing policy.</summary>
    public class CallCreditCommitmentDraft
    {
        public Guid Id { get; set; }
        public Guid ContextId { get; set; }
        public string ReviewStatus { get; set; } = "Draft";
        public decimal SuggestedAmount { get; set; }
        public decimal ObservedIntervalDays { get; set; }
        public uint? SuggestedCycleMonths { get; set; }
        public string EvidenceJson { get; set; } = "{}";
        public string DetectorVersion { get; set; } = string.Empty;
        public DateTime CreatedAtUtc { get; set; }
    }
}
