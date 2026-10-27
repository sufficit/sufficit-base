using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sufficit.Cadences
{
    /// <summary>
    ///     One run of a cadence for a subject owned by a module (contract period, invoice, DID...). Opened and closed only by
    ///     that module. Keeps a copy of the milestones of the version it opened with.
    /// </summary>
    public sealed class CadenceCase
    {
        public Guid Id { get; set; }

        public Guid CadenceId { get; set; }

        public int CadenceVersion { get; set; }

        /// <summary>Opaque to the cadence core, defined by the owner module (e.g. "sales.contract-period").</summary>
        [Required, StringLength(64)]
        public string SubjectType { get; set; } = string.Empty;

        /// <summary>Opaque identifier in the owner's format.</summary>
        [Required, StringLength(128)]
        public string SubjectId { get; set; } = string.Empty;

        public Guid? ContextId { get; set; }

        /// <summary>D0 as a calendar date (business time zone).</summary>
        public DateTime AnchorDate { get; set; }

        public CadenceCaseStatus Status { get; set; } = CadenceCaseStatus.Open;

        [StringLength(64)]
        public string? CloseReason { get; set; }

        [StringLength(160)]
        public string? OpenedBy { get; set; }

        public DateTime OpenedAtUtc { get; set; } = DateTime.UtcNow;

        public DateTime? ClosedAtUtc { get; set; }

        /// <summary>Milestones of <see cref="CadenceVersion"/>, frozen when the case opened.</summary>
        public List<CadenceMilestone> Milestones { get; set; } = new();
    }
}
