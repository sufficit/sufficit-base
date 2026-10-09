using System;
using System.Collections.Generic;

namespace Sufficit.Sales;

/// <summary>Independent collection workflow; never a commercial customer classification.</summary>
public enum ServiceCollectionStage { Review = 0, Due = 1, AwaitingPayment = 2, Upcoming = 3, Paid = 4 }

/// <summary>Effective recipient for collection communication. Revision zero denotes a read-only default; positive revisions are persisted overrides. Does not change fiscal payer or service ownership.</summary>
public sealed class ServiceCollectionProfile
{
    /// <summary>Service whose collection communication destination is resolved.</summary>
    public Guid ContractId { get; set; }
    /// <summary>Contact context authorized to receive collection communication.</summary>
    public Guid ResponsibleContextId { get; set; }
    /// <summary>Persisted override revision; zero means a derived destination without manual acceptance.</summary>
    public long Revision { get; set; }
    /// <summary>Authenticated manager who accepted this configuration.</summary>
    public Guid ActorId { get; set; }
    /// <summary>Acceptance instant, not a payment or cancellation date.</summary>
    public DateTime ChangedAtUtc { get; set; }
}

/// <summary>Reviewed recipient command. Stable request identity supports uncertain retries.</summary>
public sealed class ServiceCollectionProfileCommand
{
    /// <summary>Immutable command identity.</summary>
    public Guid RequestId { get; set; }
    /// <summary>Target service identity.</summary>
    public Guid ContractId { get; set; }
    /// <summary>Exact previously read revision; zero means no existing profile.</summary>
    public long ExpectedRevision { get; set; }
    /// <summary>Explicit verified collection recipient context.</summary>
    public Guid ResponsibleContextId { get; set; }
    /// <summary>Manager justification retained in the immutable journal.</summary>
    public string Reason { get; set; } = string.Empty;
}

/// <summary>One financial obligation or an explicit missing-evidence review row.</summary>
public sealed class ServiceCollectionRow
{
    /// <summary>Contract/service identifier.</summary>
    public Guid ContractId { get; set; }
    /// <summary>Beneficiary context; default collection recipient unless an explicit override or financial assignment applies.</summary>
    public Guid ContextId { get; set; }
    /// <summary>Visible beneficiary name when resolved through Contacts.</summary>
    public string? CustomerTitle { get; set; }
    /// <summary>Snapshot title of this service.</summary>
    public string ServiceTitle { get; set; } = string.Empty;
    /// <summary>Existing service source, retained to identify migration gaps.</summary>
    public ContractSource Source { get; set; }
    /// <summary>Declared settlement model; unspecified remains unknown.</summary>
    public ContractSettlementModel SettlementModel { get; set; }
    /// <summary>Effective collection recipient and override revision; null when identity is unresolved or conflicting.</summary>
    public ServiceCollectionProfile? Profile { get; set; }
    /// <summary>Origin of the effective destination; never implies manual confirmation for an automatic default.</summary>
    public string RecipientSource => Profile == null ? "Unresolved" : Profile.Revision > 0 ? "Explicit" :
        Profile.ResponsibleContextId == ContextId ? "Customer" : "FinancialResponsible";
    /// <summary>Verified recipient display name.</summary>
    public string? ResponsibleTitle { get; set; }
    /// <summary>Recipient's registered collection email; missing values remain explicit.</summary>
    public string? ResponsibleEmail { get; set; }
    /// <summary>Authoritative financial/operation identity; null is not an unpaid invoice.</summary>
    public Guid? ChargeId { get; set; }
    /// <summary>Linked billing period identity, if the source uses periods.</summary>
    public Guid? PeriodId { get; set; }
    /// <summary>Nominal charge amount; not a fabricated partial-payment balance.</summary>
    public decimal? Amount { get; set; }
    /// <summary>Verified source currency; missing currency prohibits totals.</summary>
    public string? Currency { get; set; }
    /// <summary>Financial due civil date in invariant yyyy-MM-dd; distinct from coverage end.</summary>
    public string? DueDate { get; set; }
    /// <summary>True for a coverage renewal reminder, never an issued invoice or debt.</summary>
    public bool IsCoverageRenewal { get; set; }
    /// <summary>Current legacy coverage end as a Brazilian civil date; not a financial due date.</summary>
    public string? CoverageEndDate { get; set; }
    /// <summary>Known coverage end precedes the reference day; does not imply blocking or a late fee.</summary>
    public bool IsCoverageExpired { get; set; }
    /// <summary>Calculated collection start civil date according to the explicit row basis.</summary>
    public string? CollectionDate { get; set; }
    /// <summary>Coverage start instant when known.</summary>
    public DateTime? CoverageStartUtc { get; set; }
    /// <summary>Exclusive coverage end instant when known.</summary>
    public DateTime? CoverageEndUtc { get; set; }
    /// <summary>Raw financial source status; not evidence of message delivery.</summary>
    public string PaymentStatus { get; set; } = "Unknown";
    /// <summary>Authoritative payment acceptance instant, never inferred from emission.</summary>
    public DateTime? ConfirmedReceiptUtc { get; set; }
    /// <summary>Renewal state kept separate from financial status.</summary>
    public string RenewalStatus { get; set; } = "Unknown";
    /// <summary>Only existing eligible checkout capabilities, never generated during reading.</summary>
    public string? CheckoutUrl { get; set; }
    /// <summary>State calculated by the server for this reference date.</summary>
    public ServiceCollectionStage Stage { get; set; }
    /// <summary>Stable diagnostic code, translated by the interface.</summary>
    public string? ReviewCode { get; set; }
    /// <summary>Whether this actor may report contact for the verified recipient.</summary>
    public bool CanRecordFollowup { get; set; }
    /// <summary>Whether an existing prepaid binding can change its opt-in through the manager API.</summary>
    public bool CanManagePrepaid { get; set; }
    /// <summary>A purchase is unsettled; changing its resource revision would invalidate its coverage basis.</summary>
    public bool HasPendingPrepaidOperation { get; set; }
    /// <summary>Whether the server currently permits enabling this existing prepaid binding.</summary>
    public bool CanEnablePrepaid { get; set; }
    /// <summary>True when a known financial due date precedes the reference civil day.</summary>
    public bool IsOverdue { get; set; }
    /// <summary>Current explicit prepaid opt-in. Does not imply that workers are enabled.</summary>
    public bool PrepaidAutoRenew { get; set; }
    /// <summary>Exact resource revision used by the opt-in compare-and-set command.</summary>
    public long? PrepaidRevision { get; set; }
}

/// <summary>Bounded authorized service page. Counts represent this page, not the whole portfolio.</summary>
public sealed class ServiceCollectionPage
{
    /// <summary>Reviewed Brazilian civil day.</summary>
    public string ReferenceDate { get; set; } = string.Empty;
    /// <summary>Requested collection lead in calendar days.</summary>
    public int LeadDays { get; set; } = 7;
    /// <summary>Worker's actual prepaid preparation lead; separate from a view filter.</summary>
    public int PrepaidLeadDays { get; set; } = 7;
    /// <summary>Whether the configured prepaid/checkout workers are enabled.</summary>
    public bool PrepaidProcessingEnabled { get; set; }
    /// <summary>Server-side verified recipient filter applied before contract pagination.</summary>
    public Guid? ResponsibleContextId { get; set; }
    /// <summary>Stable contract offset of this page.</summary>
    public int Offset { get; set; }
    /// <summary>Offset to inspect the next contract page; null indicates no more contracts.</summary>
    public int? NextOffset { get; set; }
    /// <summary>True when any source evidence cap prevents a complete result.</summary>
    public bool EvidenceTruncated { get; set; }
    /// <summary>Read observation instant; not a financial transaction instant.</summary>
    public DateTime ObservedAtUtc { get; set; }
    /// <summary>Financial rows and visible review gaps for the selected contract page.</summary>
    public List<ServiceCollectionRow> Items { get; set; } = new();
}

/// <summary>Explicit opt-in/out for an already bound prepaid service; never creates a binding.</summary>
public sealed class ServiceCollectionAutomationCommand
{
    /// <summary>Immutable authenticated command identity.</summary>
    public Guid RequestId { get; set; }
    /// <summary>Target service identity.</summary>
    public Guid ContractId { get; set; }
    /// <summary>Original resource revision, preserved for a retry.</summary>
    public long ExpectedRevision { get; set; }
    /// <summary>Original opt-in state, checked together with the revision.</summary>
    public bool ExpectedEnabled { get; set; }
    /// <summary>Reviewed desired opt-in state.</summary>
    public bool Enabled { get; set; }
}

/// <summary>Immutable confirmation of a reviewed prepaid opt-in command.</summary>
public sealed class ServiceCollectionAutomationReceipt
{
    /// <summary>Exact reviewed operation identity.</summary>
    public Guid RequestId { get; set; }
    /// <summary>Target service.</summary>
    public Guid ContractId { get; set; }
    /// <summary>Accepted resource revision.</summary>
    public long Revision { get; set; }
    /// <summary>Accepted automatic renewal intent.</summary>
    public bool Enabled { get; set; }
}
