using System;
namespace Sufficit.Sales;
/// <summary>Manager request for generic monthly continuation. Retry the original
/// predecessor snapshot; a refreshed snapshot represents a different renewal.</summary>
public sealed class LegacyMonthlyRenewalRequest
{
    public Guid ContractId { get; set; }
    public string ExpectedSnapshot { get; set; } = string.Empty;
}

/// <summary>Advisory only; the write revalidates customer/catalog authority and snapshot.</summary>
public sealed class LegacyMonthlyRenewalAvailability
{
    public bool Applicable { get; set; }
    public bool CanRenew { get; set; }
    public string? BlockReason { get; set; }
}
