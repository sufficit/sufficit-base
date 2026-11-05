using System;
using Sufficit.Telephony.DIDs.Testing;
namespace Sufficit.CheckUp
{
    /// <summary>One correlated, non-sensitive execution update streamed to the requesting operator.</summary>
    public sealed class CustomerChecklistEvent
    {
        public Guid ContextId { get; set; }
        public string Key { get; set; } = string.Empty;
        public string RunId { get; set; } = string.Empty;
        public string Stage { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? Status { get; set; }
        public string? Evidence { get; set; }
        public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;
        public Guid? BatchId { get; set; }
        public DIDTestRun? Did { get; set; }
    }
}
