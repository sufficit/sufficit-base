using System;
namespace Sufficit.Sales
{
    /// <summary>Customer-wide service continuity policy; absence preserves renewal on credit.</summary>
    public sealed class CustomerRenewalPolicy
    {
        public Guid ContextId { get; set; }
        public bool RequirePayment { get; set; }
        public long Revision { get; set; }
        public Guid ActorId { get; set; }
        public DateTime ChangedAtUtc { get; set; }
    }
    public sealed class CustomerRenewalPolicyChange
    {
        public Guid RequestId { get; set; }
        public Guid ContextId { get; set; }
        public bool RequirePayment { get; set; }
        public long ExpectedRevision { get; set; }
    }
}
