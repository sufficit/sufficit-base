#if NET10_0_OR_GREATER
using System;
using System.Collections.Generic;
using Sufficit.Gateway;
namespace Sufficit.Sales;
/// <summary>Frozen at issuance; never reconstructed from a later catalog revision.</summary>
public sealed record ContractRightsSnapshot(int SchemaVersion, Guid ContractId, Guid ContextId, Guid CatalogItemId,
    Guid ResourceId, string ResourceType, string ExternalResourceId, Guid PeriodId, DateTime StartUtc, DateTime EndUtc,
    long RecurringAmountCents, long AmountCents, Dictionary<string,long> Capacities, Dictionary<string,long> Quotas,
    Dictionary<string,long> NominalQuotas, GatewayEnvironment Environment, bool TestOnly, int CycleMonths);


#endif
