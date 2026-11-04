using System;
namespace Sufficit.Sales
{
    /// <summary>Customer-wide permission to issue direct charges; absence preserves direct billing.</summary>
    public sealed class CustomerDirectBillingPolicy
    {
        public Guid ContextId { get; set; }
        public bool Enabled { get; set; } = true;
        public long Revision { get; set; }
        public Guid ActorId { get; set; }
        public DateTime ChangedAtUtc { get; set; }
    }
    public sealed class CustomerDirectBillingPolicyChange
    {
        public Guid RequestId { get; set; }
        public Guid ContextId { get; set; }
        public bool Enabled { get; set; } = true;
        public long ExpectedRevision { get; set; }
    }
}
