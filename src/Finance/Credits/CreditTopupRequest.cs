using System;

namespace Sufficit.Finance.Credits;

public sealed class CreditTopupRequest
{
    public Guid ContextId { get; set; }
    public Guid ProductId { get; set; }
    public long AmountCents { get; set; }
    public string IdempotencyKey { get; set; } = "";
}
