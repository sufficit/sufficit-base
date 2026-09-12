using System;

namespace Sufficit.Finance.Credits;

public sealed class CreditResource
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string Title { get; set; } = "";
}
