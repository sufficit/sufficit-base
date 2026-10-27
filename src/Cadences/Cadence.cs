using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sufficit.Cadences
{
    /// <summary>
    ///     A cadence ("régua") is only a clock: named milestones counted in days from a case's anchor date (D0).
    ///     It knows nothing about contracts, notifications or blocking — modules open cases and react to the events.
    /// </summary>
    public sealed class Cadence
    {
        public Guid Id { get; set; }

        [Required, StringLength(160)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public CadenceStatus Status { get; set; } = CadenceStatus.Draft;

        /// <summary>
        ///     Kind of subject the cases of this cadence are about (from a module's <see cref="CadenceSubjectDefinition"/>).
        ///     Only milestones whose module supports this subject can be used, and cases must match it.
        /// </summary>
        [StringLength(64)]
        public string? SubjectType { get; set; }

        /// <summary>Incremented on every save; cases keep the milestones of the version they opened with.</summary>
        public int Version { get; set; }

        [StringLength(160)]
        public string? UpdatedBy { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;

        public List<CadenceMilestone> Milestones { get; set; } = new();

        /// <summary>Why this version exists; required once the cadence is active. Stored in the revision.</summary>
        [NotMapped, StringLength(500)]
        public string? ChangeReason { get; set; }
    }
}
