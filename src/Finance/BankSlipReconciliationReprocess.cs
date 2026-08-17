using System;
using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>
    /// Selects canonical bank-slip aggregates for an administrator-initiated
    /// provider refresh. Provider callbacks are not forged or duplicated.
    /// </summary>
    public sealed class BankSlipReconciliationReprocessRequest
    {
        public string Provider { get; set; } = BankSlipProviderCodes.Efi;

        /// <summary>
        /// Canonical/provider pairs selected from the reconciliation report.
        /// The service validates the provider custom identifier before it
        /// repairs a missing local charge link.
        /// </summary>
        public IReadOnlyCollection<BankSlipReconciliationReprocessTarget> Targets { get; set; }
            = Array.Empty<BankSlipReconciliationReprocessTarget>();

        /// <summary>
        /// Backward-compatible selection for records that already have a
        /// provider charge identifier stored locally.
        /// </summary>
        public IReadOnlyCollection<Guid> BankSlipIds { get; set; }
            = Array.Empty<Guid>();
    }

    public sealed class BankSlipReconciliationReprocessTarget
    {
        public Guid BankSlipId { get; set; }
        public string? ProviderChargeId { get; set; }
    }

    /// <summary>
    /// Summarizes the outcome of a bounded reconciliation reprocessing batch.
    /// </summary>
    public sealed class BankSlipReconciliationReprocessReport
    {
        public string Provider { get; set; } = string.Empty;
        public int RequestedCount { get; set; }
        public int UpdatedCount { get; set; }
        public int UnchangedCount { get; set; }
        public int PendingCount { get; set; }
        public int FailedCount { get; set; }

        public IReadOnlyList<BankSlipReconciliationReprocessItem> Items { get; set; }
            = Array.Empty<BankSlipReconciliationReprocessItem>();
    }

    /// <summary>
    /// Result for one selected canonical bank slip. Messages contain no payer
    /// data, credentials or raw provider payloads.
    /// </summary>
    public sealed class BankSlipReconciliationReprocessItem
    {
        public Guid BankSlipId { get; set; }
        public string? ProviderChargeId { get; set; }
        public string? ProviderStatus { get; set; }
        public BankSlipStatus? PreviousStatus { get; set; }
        public BankSlipStatus? CurrentStatus { get; set; }
        public Guid? IntegrationEventId { get; set; }
        public BankSlipReconciliationReprocessOutcome Outcome { get; set; }
        public string Message { get; set; } = string.Empty;

        public bool Succeeded
            => Outcome == BankSlipReconciliationReprocessOutcome.Updated
                || Outcome == BankSlipReconciliationReprocessOutcome.Unchanged;
    }

    public enum BankSlipReconciliationReprocessOutcome : byte
    {
        Updated = 1,
        Unchanged = 2,
        RequiresAttention = 3,
        NotFound = 4,
        ProviderNotFound = 5,
        ConcurrencyConflict = 6,
        Failed = 7
    }
}
