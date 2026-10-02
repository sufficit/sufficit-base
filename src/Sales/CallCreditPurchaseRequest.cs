using System;
namespace Sufficit.Sales
{
    public sealed class CallCreditPurchaseRequest
    {
        public Guid OperationId { get; set; }
        public Guid CutoverId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestedAtUtc { get; set; }
        public bool AllowWithoutBalance { get; set; }
    }
}
