using System;

namespace Sufficit.Finance.Credits;

/// <summary>One redemption binds an offer to one context/product for a fixed benefit period.</summary>
public sealed class CreditBenefit
{
    public Guid Id { get; set; }
    public Guid VoucherId { get; set; }
    public Guid AccountId { get; set; }
    public Guid ContextId { get; set; }
    public string IdempotencyKey { get; set; } = "";
    public Guid? ResourceId { get; set; }
    public decimal Percentage { get; set; }
    public long RemainingUnits { get; set; }
    public DateTime StartsUtc { get; set; }
    public DateTime EndsUtc { get; set; }
}
