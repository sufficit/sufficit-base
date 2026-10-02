using System;
namespace Sufficit.Sales
{
    public sealed class ServiceDiscountRequest
    {
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public bool WelcomeTrial { get; set; }
    }
    /// <summary>Immutable service pricing evidence; nominal value remains the call-credit amount.</summary>
    public sealed class ServiceDiscountEvidence
    {
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public Guid ActorId { get; set; }
        public string? Policy { get; set; }
        public decimal Payable(decimal nominal)
        {
            if (Amount <= 0 || Amount > nominal || ActorId == Guid.Empty || string.IsNullOrWhiteSpace(Reason))
                throw new InvalidOperationException("Invalid service discount evidence.");
            return nominal - Amount;
        }
    }
}
