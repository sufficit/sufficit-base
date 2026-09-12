using System;

namespace Sufficit.Finance.Credits;

public sealed class CreditAccountRequest
{
    public Guid ContextId { get; set; }
    public Guid ProductId { get; set; }
}
