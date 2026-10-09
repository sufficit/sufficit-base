using System;
using System.Collections.Generic;

namespace Sufficit.Sales;

/// <summary>Authorized read of a service's actual prepaid binding. No checkout capabilities or provider credentials.</summary>
public sealed class ServicePrepaidDetails
{
    public Guid ContractId { get; set; }
    public bool Bound { get; set; }
    public long? Revision { get; set; }
    public bool? AutoRenew { get; set; }
    public bool? Suspended { get; set; }
    public bool ProcessingEnabled { get; set; }
    public int RenewalLeadDays { get; set; }
    public DateTime ObservedAtUtc { get; set; }
    public bool HasPendingPayment { get; set; }
    public string? CurrentOffer { get; set; }
    public List<ServicePrepaidPlanOffer> Offers { get; set; } = new();
    public List<ServiceCatalogParameterDefinition> Parameters { get; set; } = new();
    public string? NextOffer { get; set; }
    public List<ServicePrepaidGrant> Grants { get; set; } = new();
    /// <summary>Unpaid administrative selection for renewal, distinct from already paid future grants.</summary>
    public ServicePrepaidGrant? ScheduledSelection { get; set; }
}

/// <summary>Granted capacity and allowance, not consumption measured by the consuming system.</summary>
public sealed class ServicePrepaidGrant
{
    public Guid Id { get; set; }
    public string Offer { get; set; } = string.Empty;
    public DateTime StartUtc { get; set; }
    public DateTime EndUtc { get; set; }
    public long RecurringAmountCents { get; set; }
    public Dictionary<string, long> Capacities { get; set; } = new();
    public Dictionary<string, long> Quotas { get; set; } = new();
    public Dictionary<string, long> NominalQuotas { get; set; } = new();
}
