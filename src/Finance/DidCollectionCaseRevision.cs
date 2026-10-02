using System;

namespace Sufficit.Finance
{
    public sealed class DidCollectionCaseRevision
    {
        public long Version { get; set; }
        public Guid RecordedBy { get; set; }
        public DateTime RecordedAtUtc { get; set; }
        public DidCollectionCaseSaveRequest Snapshot { get; set; } = new DidCollectionCaseSaveRequest();
    }
}
