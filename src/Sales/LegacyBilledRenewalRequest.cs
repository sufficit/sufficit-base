using System;

namespace Sufficit.Sales;

/// <summary>Explicit manager renewal. Never send a new snapshot when retrying the same operation.</summary>
public sealed class LegacyBilledRenewalRequest
{
    public Guid ContractId { get; set; }
    public string ExpectedSnapshot { get; set; } = string.Empty;
}

/// <summary>Advisory availability; the write revalidates authority and the expected snapshot.</summary>
public sealed class LegacyBilledRenewalAvailability
{
    public bool Applicable { get; set; }
    public bool CanRenew { get; set; }
    public string? BlockReason { get; set; }
}
