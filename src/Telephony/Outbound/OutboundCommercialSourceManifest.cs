using System;
using System.Collections.Generic;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>Complete view of one commercial source and context for explicit replay/reconciliation.</summary>
    public sealed class OutboundCommercialSourceManifest
    {
        public string SourceSystem { get; set; } = string.Empty;
        public Guid ContextId { get; set; }
        public DateTime GeneratedAtUtc { get; set; }
        public DateTime? LastAppliedEventAtUtc { get; set; }
        public int ScheduledCount { get; set; }
        public int ConflictCount { get; set; }
        public string Digest { get; set; } = string.Empty;
        public IReadOnlyList<OutboundCommercialSourceManifestLine> Lines { get; set; }
            = Array.Empty<OutboundCommercialSourceManifestLine>();
    }

    public sealed class OutboundCommercialSourceManifestLine
    {
        public string ExternalContractLineId { get; set; } = string.Empty;
        public Guid GrantLineId { get; set; }
        public Guid ServiceId { get; set; }
        public long SourceVersion { get; set; }
        public string? PayloadHash { get; set; }
        public OutboundAdministrativeState AdministrativeState { get; set; }
        public DateTime StartUtc { get; set; }
        public DateTime ExpirationUtc { get; set; }
        public int Channels { get; set; }
    }
}
