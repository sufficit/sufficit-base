using System;
using System.Collections.Generic;

namespace Sufficit.Telephony
{
    public class InterconnectionTestCallSession
    {
        public Guid SessionId { get; set; }

        public Guid ContextId { get; set; }

        public Guid InterconnectionId { get; set; }

        public string InterconnectionTitle { get; set; } = string.Empty;

        public string Destination { get; set; } = string.Empty;

        public string? NormalizedDestination { get; set; }

        public string? CallerId { get; set; }

        public string? OutboundProfile { get; set; }

        public string? ProvisioningPrefix { get; set; }

        public string? SelectedHostTitle { get; set; }

        public string? SelectedEndPointId { get; set; }

        public string? OriginateChannel { get; set; }

        public InterconnectionTestCallStatus Status { get; set; } = InterconnectionTestCallStatus.Pending;

        public string? Message { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? StartedAtUtc { get; set; }

        public DateTime? FinishedAtUtc { get; set; }

        public bool Completed { get; set; }

        public List<InterconnectionTestCallProgressEntry> Progress { get; set; } = new List<InterconnectionTestCallProgressEntry>();
    }

    public enum InterconnectionTestCallStatus
    {
        Pending = 0,
        Running = 1,
        Answered = 2,
        Completed = 3,
        Failed = 4,
    }
}
