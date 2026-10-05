using System;

namespace Sufficit.Operations
{
    /// <summary>Full desired work state. Authentication supplies the actor; callers cannot override it.</summary>
    public sealed class ActivityTransitionRequest
    {
        /// <summary>Stable command identifier; exact replay returns the original receipt.</summary>
        public Guid RequestId { get; set; }
        /// <summary>Stable activity identifier; never reuse it for another context.</summary>
        public Guid ActivityId { get; set; }
        /// <summary>Explicit owning customer context.</summary>
        public Guid ContextId { get; set; }
        /// <summary>Zero creates; updates require the exact current revision.</summary>
        public long ExpectedRevision { get; set; }
        /// <summary>Correlation identifier joining command and downstream evidence.</summary>
        public Guid CorrelationId { get; set; }
        /// <summary>Mandatory explanation retained in immutable history.</summary>
        public string Reason { get; set; } = string.Empty;
        /// <summary>Stable category; immutable after creation.</summary>
        public string ActivityType { get; set; } = string.Empty;
        /// <summary>Desired title, up to 250 characters.</summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>Desired operator notes, up to 4000 characters.</summary>
        public string Notes { get; set; } = string.Empty;
        /// <summary>Desired internal assignee; null explicitly removes the assignment.</summary>
        public Guid? AssigneeId { get; set; }
        /// <summary>Desired UTC deadline; null explicitly removes the deadline.</summary>
        public DateTime? DueAtUtc { get; set; }
        /// <summary>Desired state. Creation requires Open; terminal work cannot be reopened.</summary>
        public OperationalActivityStatus Status { get; set; }
        /// <summary>Optional immutable owning module entity category.</summary>
        public string? ReferenceType { get; set; }
        /// <summary>Optional immutable owning module entity identifier.</summary>
        public Guid? ReferenceId { get; set; }
        /// <summary>Optional immutable context-scoped event business key.</summary>
        public string? OriginKey { get; set; }

        /// <summary>Validates bounded identifiers and text before any persistent mutation.</summary>
        public void Validate()
        {
            if (RequestId == Guid.Empty || ActivityId == Guid.Empty || ContextId == Guid.Empty || CorrelationId == Guid.Empty)
                throw new ArgumentException("Explicit command, activity, context and correlation identifiers are required.");
            if (ExpectedRevision < 0 || ExpectedRevision == long.MaxValue || !Enum.IsDefined(typeof(OperationalActivityStatus), Status))
                throw new ArgumentException("Invalid revision or state.");
            RequireText(Reason, 1000); RequireText(ActivityType, 64); RequireText(Title, 250);
            if (Notes == null || Notes.Length > 4000) throw new ArgumentException("Invalid notes.");
            if (AssigneeId == Guid.Empty || ReferenceId == Guid.Empty || DueAtUtc.HasValue && DueAtUtc.Value.Kind != DateTimeKind.Utc)
                throw new ArgumentException("Invalid assignee, reference or UTC deadline.");
            if ((ReferenceType == null) != (ReferenceId == null)) throw new ArgumentException("Reference category and identifier must be supplied together.");
            if (ReferenceType != null) RequireText(ReferenceType, 64);
            if (OriginKey != null)
            {
                RequireText(OriginKey, 128);
                foreach (var character in OriginKey)
                    if (character < 33 || character > 126) throw new ArgumentException("Origin keys must be printable ASCII without whitespace.");
            }
            if (ExpectedRevision == 0 && Status != OperationalActivityStatus.Open)
                throw new ArgumentException("New activities must start open.");
        }

        private static void RequireText(string value, int limit)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > limit) throw new ArgumentException("Required text is missing or exceeds its limit.");
        }
    }
}
