using System;

namespace Sufficit.Finance.Credits;

public sealed class CreditVoucherEvent
{
    public Guid Id { get; set; }
    public Guid VoucherId { get; set; }
    public Guid ActorId { get; set; }
    public string Action { get; set; } = "";
    public DateTime CreatedUtc { get; set; }
}
