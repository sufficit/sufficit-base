using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>Redacted inbox conflict, scoped to the authenticated commercial source.</summary>
    public sealed class OutboundCommercialGrantConflict
    {
        public Guid EventId { get; set; }
        public string ExternalContractLineId { get; set; } = string.Empty;
        public Guid ContextId { get; set; }
        public long SourceVersion { get; set; }
        public DateTime ReceivedAtUtc { get; set; }
        public DateTime EffectiveAtUtc { get; set; }
    }
}
