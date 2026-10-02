using System;

namespace Sufficit.Finance
{
    /// <summary>Read-only recommendations, never commands or confirmation of operational effects.</summary>
    public sealed class DidCollectionEvaluation
    {
        public string PolicyVersion { get; set; } = string.Empty;
        public DateTime EvaluatedAtUtc { get; set; }
        public string? ReviewReason { get; set; }
        public bool AwaitingContact { get; set; }
        public DateTime? SuggestedExpirationUtc { get; set; }
        public bool BlockReviewDue { get; set; }
        public bool FinalNoticeDue { get; set; }
        public bool IncludePortabilityInstructions { get; set; }
        public DateTime? NextManagerReminderAtUtc { get; set; }
        public bool ManagerReminderDue { get; set; }
        public bool UnlinkReviewAvailable { get; set; }
        public bool SupplierCancellationReviewAvailable { get; set; }
        public DateTime? LocalQuarantineUntilUtc { get; set; }
    }
}
