using System;

namespace Sufficit.Cadences
{
    /// <summary>Common data of every cadence event. Modules filter by <see cref="SubjectType"/> and milestone key.</summary>
    public abstract class CadenceCaseEvent
    {
        public Guid CaseId { get; set; }
        public Guid CadenceId { get; set; }
        public int CadenceVersion { get; set; }
        public string SubjectType { get; set; } = string.Empty;
        public string SubjectId { get; set; } = string.Empty;
        public Guid? ContextId { get; set; }
        public DateTime AnchorDate { get; set; }
        public DateTime OccurredAtUtc { get; set; } = DateTime.UtcNow;
        /// <summary>True while cadences run in simulation: consumers must not apply effects.</summary>
        public bool Simulated { get; set; }
    }

    /// <summary><c>cadence.case.opened</c></summary>
    public sealed class CadenceCaseOpenedEvent : CadenceCaseEvent { }

    /// <summary><c>cadence.milestone.reached</c> — the module that owns the milestone key decides what to do.</summary>
    public sealed class CadenceMilestoneReachedEvent : CadenceCaseEvent
    {
        public Guid OccurrenceId { get; set; }
        public string MilestoneKey { get; set; } = string.Empty;
        public int OffsetDays { get; set; }
        public DateTime DueDate { get; set; }
        public bool Late { get; set; }
    }

    /// <summary><c>cadence.case.closed</c> — e.g. paid or cancelled; modules undo what they applied if they want.</summary>
    public sealed class CadenceCaseClosedEvent : CadenceCaseEvent
    {
        public string? Reason { get; set; }
    }

    /// <summary><c>cadence.case.rescheduled</c> — D0 moved; pending milestones follow the new date.</summary>
    public sealed class CadenceCaseRescheduledEvent : CadenceCaseEvent
    {
        public DateTime PreviousAnchorDate { get; set; }
    }
}
