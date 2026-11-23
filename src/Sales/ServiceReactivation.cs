using System;
using System.Collections.Generic;

namespace Sufficit.Sales;

/// <summary>A reviewed monthly return agreement. The same operation identity and quote are reused after response loss.</summary>
public sealed class ServiceReactivation
{
    public Guid OperationId { get; set; }
    public Guid ContextId { get; set; }
    public DateTime Start { get; set; }
    public List<Guid> Contracts { get; set; } = new();
    public int? PaymentCode { get; set; }
    public string? ReviewedQuote { get; set; }
    public bool AuthorizeReversals { get; set; }
    public string Reason { get; set; } = string.Empty;
}

public sealed class ServiceReactivationItem
{
    public Guid ContractId { get; set; }
    public DateTime Revision { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal MonthlyAmount { get; set; }
    public Guid? FirstCyclePeriodId { get; set; }
    public bool FirstCycleIssued => FirstCyclePeriodId.HasValue;
}

public sealed class ServiceReactivationDebit
{
    public Guid ContractId { get; set; }
    public Guid PeriodId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public decimal Amount { get; set; }
    public int Code { get; set; }
    public Guid RecordId { get; set; }
    public DateTime RecordRevision { get; set; }
    public int? ReversalCode { get; set; }
}

public sealed class ServiceReactivationResult
{
    public Guid OperationId { get; set; }
    public Guid ContextId { get; set; }
    public DateTime Start { get; set; }
    public DateTime NextCycle { get; set; }
    public List<ServiceReactivationItem> Items { get; set; } = new();
    public List<ServiceReactivationDebit> Debits { get; set; } = new();
    public int? PaymentCode { get; set; }
    public decimal? PaymentAmount { get; set; }
    public Guid? PaymentId { get; set; }
    public DateTime? PaymentRevision { get; set; }
    public string Quote { get; set; } = string.Empty;
    public bool Confirmed { get; set; }
}
