using System;

namespace Sufficit.Finance.Credits;

public sealed class CreditTopup
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public string IdempotencyKey { get; set; } = "";
    public long AmountCents { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime ExpiresUtc { get; set; }
    public DateTime? ConfirmedUtc { get; set; }
    public DateTime? LastCheckedUtc { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public string QuoteToken { get; set; } = "";
    public string CheckoutUrl { get; set; } = "";
}
