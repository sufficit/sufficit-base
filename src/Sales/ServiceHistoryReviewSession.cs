using System;

namespace Sufficit.Sales
{
    /// <summary>Current commercial authority for a manager review; contains no authentication secrets.</summary>
    public sealed class ServiceHistoryReviewSession
    {
        /// <summary>Authority marker checked on every historical read and correction.</summary>
        public string Epoch { get; set; } = string.Empty;
        /// <summary>Verified source snapshot used to resolve historical service identities.</summary>
        public Guid SnapshotId { get; set; }
        /// <summary>Commercial cutover identity required by revision-checked commands.</summary>
        public Guid CutoverId { get; set; }
    }
}
