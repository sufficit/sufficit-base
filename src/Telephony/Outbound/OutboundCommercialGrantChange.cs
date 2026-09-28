using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>Full commercial line state emitted by an authenticated source.</summary>
    public sealed class OutboundCommercialGrantChange
    {
        public Guid EventId { get; set; }
        public int SchemaVersion { get; set; } = 1;
        public string SourceSystem { get; set; } = string.Empty;
        public string ExternalContractLineId { get; set; } = string.Empty;
        public Guid ContextId { get; set; }
        public Guid ServiceId { get; set; }
        public long SourceVersion { get; set; }
        public DateTime EffectiveAtUtc { get; set; }
        public DateTime StartUtc { get; set; }
        public DateTime ExpirationUtc { get; set; }
        public int Channels { get; set; }
        public OutboundAdministrativeState AdministrativeState { get; set; }
        public OutboundCommercialGrantChangeKind Kind { get; set; }
        public string PayloadHash { get; set; } = string.Empty;
    }

    public enum OutboundCommercialGrantChangeKind
    {
        Created = 1,
        Renewed = 2,
        LimitsChanged = 3,
        Suspended = 4,
        Resumed = 5,
        Revoked = 6,
    }

    public enum OutboundCommercialGrantApplyStatus
    {
        Applied = 1,
        Duplicate = 2,
        Stale = 3,
        Scheduled = 4,
    }

    public sealed class OutboundCommercialGrantApplyResult
    {
        public OutboundCommercialGrantApplyStatus Status { get; set; }
        public Guid? GrantLineId { get; set; }
        public long? Revision { get; set; }
        public long? SourceVersion { get; set; }
    }
}
