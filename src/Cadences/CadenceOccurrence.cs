using System;
using System.ComponentModel.DataAnnotations;

namespace Sufficit.Cadences
{
    /// <summary>A milestone reached by a case. Unique per case and milestone key: emitted exactly once.</summary>
    public sealed class CadenceOccurrence
    {
        public Guid Id { get; set; }

        public Guid CaseId { get; set; }

        public Guid CadenceId { get; set; }

        [Required, StringLength(96)]
        public string MilestoneKey { get; set; } = string.Empty;

        /// <summary>Calendar date the milestone was due (D0 + offset).</summary>
        public DateTime DueDate { get; set; }

        public DateTime EmittedAtUtc { get; set; } = DateTime.UtcNow;

        /// <summary>Emitted after its due date (system was down, or D0 moved into the past).</summary>
        public bool Late { get; set; }

        /// <summary>Recorded while cadences run in simulation: consumers must not apply effects.</summary>
        public bool Simulated { get; set; }
    }
}
