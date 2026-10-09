using System;
using System.Collections.Generic;
namespace Sufficit.Sales;

/// <summary>Operator-reported contact only; never provider delivery, payment or renewal evidence.</summary>
public sealed class ServiceCollectionFollowupCommand
{
    public Guid RequestId { get; set; }
    public Guid ContractId { get; set; }
    public long ExpectedRevision { get; set; }
    public Guid ResponsibleContextId { get; set; }
    public long ExpectedRecipientRevision { get; set; }
    public string Channel { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public DateTime ContactedAtUtc { get; set; }
    public string? NextFollowupDate { get; set; }
}
/// <summary>Immutable acceptance of an operator declaration, with authenticated authorship.</summary>
public sealed class ServiceCollectionFollowupReceipt
{
    public Guid RequestId { get; set; }
    public Guid ContractId { get; set; }
    public long Revision { get; set; }
    public Guid ActorId { get; set; }
    public DateTime RecordedAtUtc { get; set; }
    public ServiceCollectionFollowupCommand Report { get; set; } = new();
}
/// <summary>Current follow-up and bounded immutable contact history.</summary>
public sealed class ServiceCollectionFollowupPage
{
    public Guid ContractId { get; set; }
    public ServiceCollectionFollowupReceipt? Current { get; set; }
    public List<ServiceCollectionFollowupReceipt> Items { get; set; } = new();
    public long? NextAfterRevision { get; set; }
}
