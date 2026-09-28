using System;
using System.Collections.Generic;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>Complete replay for one source/context; missing lines never imply revocation.</summary>
    public sealed class OutboundCommercialSnapshotImport
    {
        public string SourceSystem { get; set; } = string.Empty;
        public Guid ContextId { get; set; }
        public bool Complete { get; set; }
        public string ManifestDigest { get; set; } = string.Empty;
        public IReadOnlyList<OutboundCommercialGrantChange> Lines { get; set; }
            = Array.Empty<OutboundCommercialGrantChange>();
    }

    public sealed class OutboundCommercialSnapshotImportResult
    {
        public int Applied { get; set; }
        public int Duplicate { get; set; }
        public int Stale { get; set; }
        public int Scheduled { get; set; }
        public Guid? ConflictEventId { get; set; }
        public string? ConflictReason { get; set; }
        public string CurrentManifestDigest { get; set; } = string.Empty;
        public bool Converged { get; set; }
    }
}
