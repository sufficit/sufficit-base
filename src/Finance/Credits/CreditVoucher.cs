using System;

namespace Sufficit.Finance.Credits;

/// <summary>Immutable published offer. Disable stops new redemptions, not existing benefits.</summary>
public sealed class CreditVoucher
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public Guid? ProductId { get; set; }
    public Guid? ResourceId { get; set; }
    public Guid? ContextId { get; set; }
    public decimal Percentage { get; set; }
    public long FixedUnits { get; set; }
    public DateTime StartsUtc { get; set; }
    public DateTime EndsUtc { get; set; }
    public int DurationDays { get; set; } = 30;
    public int MaxRedemptions { get; set; } = 1;
    public int MaxPerContext { get; set; } = 1;
    public bool Enabled { get; set; } = true;
    public Guid CreatedBy { get; set; }
    public DateTime CreatedUtc { get; set; }
}
