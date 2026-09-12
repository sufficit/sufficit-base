using System;

namespace Sufficit.Finance.Credits;

public sealed class CreditRedeemRequest
{
    public Guid ContextId { get; set; }
    public Guid ProductId { get; set; }
    public Guid VoucherId { get; set; }
    public string IdempotencyKey { get; set; } = "";
}
