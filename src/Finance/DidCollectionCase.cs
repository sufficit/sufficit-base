using System;

namespace Sufficit.Finance
{
    /// <summary>Verified evidence for a single customer's DID and overdue service cycle.</summary>
    public sealed class DidCollectionCase
    {
        public Guid ContextId { get; set; }
        public Guid DidId { get; set; }
        public DidCollectionKind Kind { get; set; }
        public DateTime DueAtUtc { get; set; }
        public bool Settled { get; set; }
        public bool Blocked { get; set; }
        public bool Unlinked { get; set; }
        public bool SupplierManagesQuarantine { get; set; }
        /// <summary>Both timestamps must refer to the same verified collection message for this cycle.</summary>
        public string? ContactMessageId { get; set; }
        public DateTime? DeliveredAtUtc { get; set; }
        public DateTime? ReadAtUtc { get; set; }
        public DateTime? FinalNoticeRecordedAtUtc { get; set; }
        public DateTime? LastManagerReminderAtUtc { get; set; }
    }
}
