using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>Persisted revision reference; receivers must reload authority data.</summary>
    public sealed class OutboundAuthorityNotice
    {
        public Guid EventId { get; set; }
        public Guid ContextId { get; set; }
        public Guid EntityId { get; set; }
        public long Revision { get; set; }
        public string EventType { get; set; } = string.Empty;
        public DateTime OccurredAtUtc { get; set; }
        public Guid LeaseId { get; set; }
        public int DeliveryAttempt { get; set; }
    }
}
