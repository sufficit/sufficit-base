using System;
using System.Collections.Generic;
namespace Sufficit.Sales;

/// <summary>Complete customer/recipient window, never an invoice created by reading.</summary>
public sealed class ServiceCollectionPeriodPlan
{
    public Guid Id { get; set; }
    public Guid ContextId { get; set; }
    public Guid ResponsibleContextId { get; set; }
    public string Month { get; set; } = string.Empty;
    public string Fingerprint { get; set; } = string.Empty;
    public string FirstDate { get; set; } = string.Empty;
    public string LastDate { get; set; } = string.Empty;
    public string CollectionDate { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;
    public List<ServiceCollectionRow> Items { get; set; } = new();
    public ServiceCollectionPeriodReceipt? LastContact { get; set; }
    /// <summary>Recent immutable report for this exact service snapshot, if present; absence does not prove no older/external contact.</summary>
    public ServiceCollectionPeriodReceipt? IncludedContact { get; set; }
    public bool CanRecordContact { get; set; }
    public bool Complete { get; set; }
    public string HistorySource { get; set; } = "OperatorReportsOnly";
}

/// <summary>Reviewed operator declaration shared by all services in a customer month.</summary>
public sealed class ServiceCollectionPeriodCommand
{
    public Guid RequestId { get; set; }
    public Guid PlanId { get; set; }
    public Guid ContextId { get; set; }
    public Guid ResponsibleContextId { get; set; }
    public string Month { get; set; } = string.Empty;
    public string ReferenceDate { get; set; } = string.Empty;
    public int LeadDays { get; set; } = 7;
    public int GroupDays { get; set; } = 7;
    public string Fingerprint { get; set; } = string.Empty;
    public List<Guid> ContractIds { get; set; } = new();
    public long ExpectedRevision { get; set; }
    public string Kind { get; set; } = "Initial";
    public string Channel { get; set; } = "WhatsApp";
    public string Notes { get; set; } = string.Empty;
    public DateTime ContactedAtUtc { get; set; }
    public string? NextFollowupDate { get; set; }
    public bool ExternalHistoryChecked { get; set; }
}
public sealed class ServiceCollectionPeriodReceipt
{
    public Guid RequestId { get; set; }
    public long Revision { get; set; }
    public Guid ActorId { get; set; }
    public DateTime RecordedAtUtc { get; set; }
    public ServiceCollectionPeriodCommand Report { get; set; } = new();
}
public sealed class ServiceCollectionPeriodHistory
{
    public ServiceCollectionPeriodReceipt? Current { get; set; }
    public List<ServiceCollectionPeriodReceipt> Items { get; set; } = new();
    public long? NextAfterRevision { get; set; }
}
