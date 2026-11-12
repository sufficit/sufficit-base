#if NET10_0_OR_GREATER
using System;
using System.Collections.Generic;
using Sufficit.Gateway;
namespace Sufficit.Sales;
public sealed class QuotaCheckoutStatus
{
    public System.Collections.Generic.List<ChargePaymentStatus>? ChargePayments { get; set; }
    public Guid SessionId { get; set; }
    public bool TestPayment { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTimeOffset? PaidAt { get; set; }
    public string? PaidAtSource { get; set; }
    public DateTimeOffset? ConfirmedReceiptUtc { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
}

public sealed class ChargePaymentStatus
{
    public Guid Id { get; set; }
    public long AmountCents { get; set; }
    public int Method { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ConfirmedReceiptUtc { get; set; }
}


#endif
