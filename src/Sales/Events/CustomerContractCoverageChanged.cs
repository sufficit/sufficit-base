using System;
using System.Collections.Generic;

namespace Sufficit.Sales.Events;

/// <summary>
/// Versioned commercial coverage snapshot. Not a payment, provisioning command or
/// authority to credit calls. Dates retain the commercial calendar semantics.
/// An empty Contracts list explicitly removes prior coverage for this customer.
/// </summary>
public sealed class CustomerContractCoverageChanged
{
    public const string EventType = "sales.customer-contract-coverage.changed.v1";
    public int SchemaVersion { get; set; } = 1;
    public Guid EventId { get; set; }
    public Guid ContextId { get; set; }
    public long Version { get; set; }
    public DateTime OccurredAtUtc { get; set; }
    // Shared by snapshots for both owners when a contract moves between customers.
    public Guid CorrelationId { get; set; }
    public string Producer { get; set; } = "sales";
    public List<ContractCoverageSnapshot> Contracts { get; set; } = new();
}

public sealed class ContractCoverageSnapshot
{
    public Guid ContractId { get; set; }
    public Guid? CatalogItemId { get; set; }
    public ContractStatus Status { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public DateTime? BillingDate { get; set; }
    public List<ContractCoverageInterruption> Interruptions { get; set; } = new();
}

public sealed class ContractCoverageInterruption
{
    public Guid Id { get; set; }
    public ContractInterruptionType Type { get; set; }
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }
}
