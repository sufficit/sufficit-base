using System;

namespace Sufficit.Operations
{
    /// <summary>The independent lifecycle of collaborator work; never changes billing or provisioning.</summary>
    public enum OperationalActivityStatus { Open, InProgress, WaitingExternal, Completed, Canceled }

    /// <summary>A context-scoped unit of collaborator work, with an optimistic revision.</summary>
    public sealed class OperationalActivity
    {
        /// <summary>Stable identifier generated before the first command.</summary>
        public Guid Id { get; set; }
        /// <summary>Customer context that owns the activity and its history.</summary>
        public Guid ContextId { get; set; }
        /// <summary>Stable business category, independent from the owning module's status.</summary>
        public string ActivityType { get; set; } = string.Empty;
        /// <summary>Human-readable description of the work.</summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>Operator notes; never store credentials or sensitive document contents.</summary>
        public string Notes { get; set; } = string.Empty;
        /// <summary>Internal assignee identity; null means the work remains unassigned.</summary>
        public Guid? AssigneeId { get; set; }
        /// <summary>Optional deadline expressed in UTC.</summary>
        public DateTime? DueAtUtc { get; set; }
        /// <summary>Current work state; terminal states retain all records.</summary>
        public OperationalActivityStatus Status { get; set; }
        /// <summary>Monotonically increasing revision used to reject stale writes.</summary>
        public long Revision { get; set; }
        /// <summary>Correlation identifier of the latest accepted command.</summary>
        public Guid CorrelationId { get; set; }
        /// <summary>Server-recorded creation time in UTC.</summary>
        public DateTime CreatedAtUtc { get; set; }
        /// <summary>Server-recorded latest accepted command time in UTC.</summary>
        public DateTime UpdatedAtUtc { get; set; }
        /// <summary>Optional owning module entity category; immutable after creation.</summary>
        public string? ReferenceType { get; set; }
        /// <summary>Opaque owning module entity identifier; does not grant access to that entity.</summary>
        public Guid? ReferenceId { get; set; }
        /// <summary>Optional context-scoped, case-sensitive event business key preventing duplicate work.</summary>
        public string? OriginKey { get; set; }
    }
}
