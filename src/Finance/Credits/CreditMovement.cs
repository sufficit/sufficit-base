using System;

namespace Sufficit.Finance.Credits;

public sealed class CreditMovement
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid ReferenceId { get; set; }
    public string Kind { get; set; } = "";
    public long MoneyDeltaUnits { get; set; }
    public long MoneyAfterUnits { get; set; }
    public long GrossUnits { get; set; }
    public long DiscountUnits { get; set; }
    public long PromotionalUnits { get; set; }
    public long UnchargedUnits { get; set; }
    public DateTime CreatedUtc { get; set; }
    public string DetailsJson { get; set; } = "{}";
    public string RequestHash { get; set; } = "";
}
