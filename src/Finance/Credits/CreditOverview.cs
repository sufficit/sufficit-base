using System;

namespace Sufficit.Finance.Credits;

public sealed class CreditOverview
{
    public CreditAccount Account { get; set; } = new CreditAccount();
    public bool CanConsume { get; set; }
    public CreditBenefit[] Benefits { get; set; } = Array.Empty<CreditBenefit>();
    public CreditTopup[] Topups { get; set; } = Array.Empty<CreditTopup>();
    public CreditMovement[] Movements { get; set; } = Array.Empty<CreditMovement>();
}
