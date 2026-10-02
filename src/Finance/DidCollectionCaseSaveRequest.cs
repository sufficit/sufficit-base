using System;

namespace Sufficit.Finance
{
    public sealed class DidCollectionCaseSaveRequest
    {
        public Guid CaseId { get; set; }
        public Guid OperationId { get; set; }
        public long ExpectedVersion { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DidCollectionPolicy Policy { get; set; } = new DidCollectionPolicy();
        /// <summary>Manager-verified evidence. Recording it does not perform the reported operation.</summary>
        public DidCollectionCase Evidence { get; set; } = new DidCollectionCase();
    }
}
