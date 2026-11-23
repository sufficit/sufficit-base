using System;
using System.Collections.Generic;

namespace Sufficit.Sales;

public sealed class ServiceReactivationInterventions
{
    public int GraceMinutes { get; set; }
    public int Total { get; set; }
    public List<ServiceReactivationIntervention> Items { get; set; } = new();
}

public sealed class ServiceReactivationIntervention
{
    public Guid OperationId { get; set; }
    public Guid ContractId { get; set; }
    public Guid ContextId { get; set; }
    public string? CustomerTitle { get; set; }
    public string ServiceTitle { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public decimal ExpectedAmount { get; set; }
    public decimal? PostedAmount { get; set; }
    public DateTime SinceUtc { get; set; }
}
