using System;

namespace Sufficit.Sales
{
    /// <summary>
    /// Customer portfolio entry: the customer is represented by <see cref="RepresentativeId"/>
    /// with a share of the commission during [<see cref="StartUtc"/>, <see cref="EndUtc"/>).
    /// History is immutable: changes end the current entry and open a new one.
    /// </summary>
    public class RepresentativeAssignment
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid RepresentativeId { get; set; }

        /// <summary>Fraction of the commission (0 &lt; share ≤ 1). Active shares of a customer sum to at most 1.</summary>
        public decimal Share { get; set; } = 1m;

        /// <summary>Commission policy; null uses the representative default.</summary>
        public Guid? PolicyId { get; set; }

        public DateTime StartUtc { get; set; }
        public DateTime? EndUtc { get; set; }

        /// <summary>When ended by a change: whether periods in progress stayed with this representative.</summary>
        public bool? InProgressKept { get; set; }

        public Guid CreatedBy { get; set; }
        public Guid? EndedBy { get; set; }
        public string? EndReason { get; set; }

        /// <summary>Display titles filled on reads.</summary>
        public string? CustomerTitle { get; set; }
        public string? RepresentativeTitle { get; set; }

        public bool IsActiveAt(DateTime utc) => StartUtc <= utc && (!EndUtc.HasValue || EndUtc.Value > utc);
    }

    /// <summary>What happens to commission periods already in progress when a representative changes.</summary>
    public enum InProgressPeriods
    {
        /// <summary>Periods already started keep paying the previous representative.</summary>
        KeepWithPrevious = 1,
        /// <summary>Periods already started move to the new representative (nothing already paid is reversed).</summary>
        MoveToNew = 2
    }

    /// <summary>
    /// Assigns (or replaces) a representative for a customer. The caller must answer
    /// <see cref="InProgress"/> whenever <see cref="ReplaceAssignmentId"/> is set.
    /// </summary>
    public class RepresentativeAssignmentChange
    {
        public Guid CustomerId { get; set; }
        public Guid RepresentativeId { get; set; }
        public decimal Share { get; set; } = 1m;
        public Guid? PolicyId { get; set; }

        /// <summary>Effective instant; defaults to now.</summary>
        public DateTime? EffectiveUtc { get; set; }

        /// <summary>Active assignment being replaced (ended at the effective instant), if any.</summary>
        public Guid? ReplaceAssignmentId { get; set; }

        /// <summary>Required when replacing: destination of the periods in progress.</summary>
        public InProgressPeriods? InProgress { get; set; }

        public string? Reason { get; set; }
    }
}
