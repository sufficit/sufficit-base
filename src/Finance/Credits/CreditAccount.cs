using System;

namespace Sufficit.Finance.Credits;

public sealed class CreditAccount
{
    public Guid Id { get; set; }
    public Guid ContextId { get; set; }
    public Guid ProductId { get; set; }
    public string Currency { get; set; } = "BRL";
    public long MoneyUnits { get; set; }
    public DateTime? MoneyAvailableSinceUtc { get; set; }
    public long Revision { get; set; }
    public DateTime CreatedUtc { get; set; }
}
