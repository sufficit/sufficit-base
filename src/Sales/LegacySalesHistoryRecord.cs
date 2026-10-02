using System;
namespace Sufficit.Sales;

/// <summary>Lossless historical evidence, including incomplete legacy rows.
/// Not an active contract and not permission to provision or bill.</summary>
public sealed class LegacySalesHistoryRecord
{
    public int Code { get; set; }
    public Guid? Id { get; set; }
    public Guid? ContextId { get; set; }
    public DateTime? Timestamp { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public DateTime? Billing { get; set; }
    public DateTime? Update { get; set; }
    public long? Cliente { get; set; }
    public string? Description { get; set; }
    public string? Extra { get; set; }
    public decimal? Value { get; set; }
    public bool? Renewed { get; set; }
    public string? Kind { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CommissionedId { get; set; }
    public decimal? Commission { get; set; }
}
