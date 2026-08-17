using System;
using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>
    /// Result of a live provider-to-database comparison. The report contains no
    /// payer identity or provider credentials.
    /// </summary>
    public sealed class BankSlipReconciliationReport
    {
        public string Provider { get; set; } = string.Empty;
        public string Environment { get; set; } = string.Empty;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime ComparedAtUtc { get; set; }
        public int ProviderRequestCount { get; set; }
        public int ProviderCount { get; set; }
        public int LocalCount { get; set; }
        public int MatchedCount { get; set; }
        public int ConsistentCount { get; set; }
        public int DivergenceCount { get; set; }
        public int ProviderOnlyCount { get; set; }
        public int LocalOnlyCount { get; set; }
        /// <summary>
        /// Local rows that could not be classified as provider-only or
        /// local-only because the provider inventory was incomplete.
        /// </summary>
        public int UnverifiedLocalCount { get; set; }
        public bool ProviderTruncated { get; set; }
        public bool ProviderPartial { get; set; }
        public string? ProviderWarningCode { get; set; }
        public string? ProviderWarningMessage { get; set; }
        public bool LocalTruncated { get; set; }
        public IReadOnlyList<BankSlipReconciliationItem> Items { get; set; }
            = Array.Empty<BankSlipReconciliationItem>();
    }

    public sealed class BankSlipReconciliationItem
    {
        public Guid? BankSlipId { get; set; }
        public Guid? ContextId { get; set; }
        public string? ProviderChargeId { get; set; }
        public string? ProviderCustomId { get; set; }
        public DateTime? ProviderCreatedAtUtc { get; set; }
        public DateTime? LocalCreatedAtUtc { get; set; }
        public decimal? ProviderValue { get; set; }
        public decimal? LocalValue { get; set; }
        public string? ProviderStatus { get; set; }
        public string? LocalProviderStatus { get; set; }
        public BankSlipStatus? ExpectedLocalStatus { get; set; }
        public BankSlipStatus? LocalStatus { get; set; }
        public BankSlipReconciliationOutcome Outcome { get; set; }
        public string Detail { get; set; } = string.Empty;

        public bool IsConsistent => Outcome == BankSlipReconciliationOutcome.Consistent;
    }

    public enum BankSlipReconciliationOutcome : byte
    {
        Consistent = 1,
        ProviderOnly = 2,
        LocalOnly = 3,
        StatusMismatch = 4,
        ValueMismatch = 5,
        StatusAndValueMismatch = 6
    }
}
