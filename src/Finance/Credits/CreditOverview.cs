using System;

namespace Sufficit.Finance.Credits;

public sealed class CreditOverview
{
    public CreditAccount Account { get; set; } = new CreditAccount();
    /// <summary>Total confirmed paid and redeemed fixed promotional credit ever received by this account,
    /// in billionths of BRL. Includes subsequently spent or expired credit; excludes percentage discounts
    /// and pending payments. Null when the producer does not supply the complete historical total.</summary>
    public decimal? TotalReceivedUnits { get; set; }
    public bool CanConsume { get; set; }
    public CreditBenefit[] Benefits { get; set; } = Array.Empty<CreditBenefit>();
    public CreditTopup[] Topups { get; set; } = Array.Empty<CreditTopup>();
    public CreditMovement[] Movements { get; set; } = Array.Empty<CreditMovement>();
}
