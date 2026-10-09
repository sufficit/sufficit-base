using System;
using System.Collections.Generic;
namespace Sufficit.Sales;

/// <summary>Reviewed totals for a bound service. Prices and effective dates are determined by Services.</summary>
public sealed class ServicePrepaidPlanCommand
{
    public Guid ContractId { get; set; }
    public Guid RequestId { get; set; }
    public long ExpectedRevision { get; set; }
    public string Offer { get; set; } = string.Empty;
    public Dictionary<string, long> Totals { get; set; } = new();
    public long? ExpectedAmountCents { get; set; }
}
public sealed class ServicePrepaidPlanQuote
{
    public long AmountNowCents { get; set; }
    public bool ScheduleOnly { get; set; }
    public ServicePrepaidGrant? ImmediateGrant { get; set; }
    public ServicePrepaidGrant RenewalGrant { get; set; } = new();
}
public sealed class ServicePrepaidPlanOperation
{
    public Guid OperationId { get; set; }
    public string State { get; set; } = string.Empty;
    public string? CheckoutUrl { get; set; }
}
public sealed class ServicePrepaidPlanOffer
{
    public string Code { get; set; } = string.Empty;
    public long PriceCents { get; set; }
    public int Months { get; set; }
    public Dictionary<string, long> Capacities { get; set; } = new();
    public Dictionary<string, long> Quotas { get; set; } = new();
    public Dictionary<string, ServicePrepaidPlanUnit> UnitPrices { get; set; } = new();
}
public sealed class ServicePrepaidPlanUnit
{
    public long PriceCents { get; set; }
    public long Step { get; set; }
    public long MaxIncrease { get; set; }
    public bool Quota { get; set; }
    public string? Label { get; set; }
    public string? Unit { get; set; }
    public long StorageScale { get; set; } = 1;
}
