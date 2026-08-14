namespace Sufficit.Finance
{
    /// <summary>
    /// PII-free outcome of a consistency pass across provider inbox, bank-slip
    /// outbox and the financial projection inbox.
    /// </summary>
    public sealed class BankSlipConsistencyResult
    {
        public int StuckNotificationCount { get; set; }
        public int ReleasedNotificationCount { get; set; }
        public int PendingProviderEventCount { get; set; }
        public int StaleOutboxCount { get; set; }
        public int AuditedProjectionCount { get; set; }
        public int RequeuedProjectionCount { get; set; }
        public int SandboxProjectionCount { get; set; }
        public int QuarantinedEnvelopeCount { get; set; }
        public int RemainingAuditCandidateCount { get; set; }
        public int ProviderCheckedCount { get; set; }
        public int ProviderUpdatedCount { get; set; }
        public int ProviderMismatchCount { get; set; }
        public int ProviderFailureCount { get; set; }
        public int RemainingProviderCandidateCount { get; set; }

        public bool RequiresAttention
            => StuckNotificationCount > 0
            || ReleasedNotificationCount > 0
            || PendingProviderEventCount > 0
            || StaleOutboxCount > 0
            || RequeuedProjectionCount > 0
            || QuarantinedEnvelopeCount > 0
            || RemainingAuditCandidateCount > 0
            || ProviderMismatchCount > 0
            || ProviderFailureCount > 0
            || RemainingProviderCandidateCount > 0;
    }
}
