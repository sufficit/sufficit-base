using System;
using System.Globalization;

namespace Sufficit.Operations
{
    /// <summary>
    /// An explicit source request to open collaborator work. Receiving an arbitrary
    /// sales, payment or telephony event does not implicitly create this request.
    /// </summary>
    public sealed class OperationalActivityRequestedEvent
    {
        /// <summary>Stable source event identity; reused as the creation command and activity identity.</summary>
        public Guid EventId { get; set; }
        /// <summary>Owning customer context, never inferred from the authenticated actor.</summary>
        public Guid ContextId { get; set; }
        /// <summary>Correlation identity connecting this request to its source operation.</summary>
        public Guid CorrelationId { get; set; }
        /// <summary>Original UTC occurrence recorded in the immutable creation receipt.</summary>
        public DateTime OccurredAtUtc { get; set; }
        /// <summary>Source explanation, up to 900 characters; does not contain an actor override.</summary>
        public string Reason { get; set; } = string.Empty;
        /// <summary>Business category of the requested work, independent of module lifecycle states.</summary>
        public string ActivityType { get; set; } = string.Empty;
        /// <summary>Human-readable title of the requested work.</summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>Operator notes without credentials or sensitive document contents.</summary>
        public string Notes { get; set; } = string.Empty;
        /// <summary>Optional internal assignee; null retains visible unassigned work.</summary>
        public Guid? AssigneeId { get; set; }
        /// <summary>Optional UTC deadline; never automatically cancels or provisions a service.</summary>
        public DateTime? DueAtUtc { get; set; }
        /// <summary>Optional immutable owning module entity category.</summary>
        public string? ReferenceType { get; set; }
        /// <summary>Optional immutable owning module entity identity.</summary>
        public Guid? ReferenceId { get; set; }

        /// <summary>
        /// Creates a deterministic creation command. Exact event replay returns its
        /// original authenticated receipt even after later operator edits.
        /// </summary>
        public ActivityTransitionRequest ToCommand()
        {
            if (EventId == Guid.Empty || OccurredAtUtc == default || OccurredAtUtc.Kind != DateTimeKind.Utc)
                throw new ArgumentException("An explicit source event and UTC occurrence are required.");
            if (string.IsNullOrWhiteSpace(Reason) || Reason.Length > 900)
                throw new ArgumentException("A bounded source explanation is required.");
            var command = new ActivityTransitionRequest
            {
                RequestId = EventId, ActivityId = EventId, ContextId = ContextId,
                CorrelationId = CorrelationId, ExpectedRevision = 0, Status = OperationalActivityStatus.Open,
                OriginKey = "event:" + EventId.ToString("N"), ActivityType = ActivityType,
                Title = Title, Notes = Notes, AssigneeId = AssigneeId, DueAtUtc = DueAtUtc,
                ReferenceType = ReferenceType, ReferenceId = ReferenceId,
                Reason = "Source event " + EventId.ToString("D") + " at " +
                    OccurredAtUtc.ToString("O", CultureInfo.InvariantCulture) + ": " + Reason
            };
            command.Validate();
            return command;
        }
    }
}
