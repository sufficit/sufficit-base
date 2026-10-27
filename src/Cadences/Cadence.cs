using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sufficit.Cadences
{
    /// <summary>
    ///     Versioned schedule ("régua") of steps counted in days from an anchor date (due date, coverage end, event...).
    ///     Generic across modules: it lives in the database, is applied to targets of any module and is read by the
    ///     consumers that execute its actions. Nothing is hardcoded.
    /// </summary>
    public sealed class Cadence
    {
        public Guid Id { get; set; }

        [Required, StringLength(160)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        /// <summary>Owning module, key from <see cref="CadenceModules"/>.</summary>
        [Required, StringLength(32)]
        public string Module { get; set; } = CadenceModules.Sales;

        public CadenceKind Kind { get; set; } = CadenceKind.CutOff;

        public CadenceStatus Status { get; set; } = CadenceStatus.Draft;

        /// <summary>Date offsets are counted from, key from <see cref="CadenceAnchors"/>.</summary>
        [Required, StringLength(32)]
        public string Anchor { get; set; } = CadenceAnchors.DueDate;

        /// <summary>Incremented on every save; executions record the version they followed.</summary>
        public int Version { get; set; }

        /// <summary>Resolving the case (e.g. payment) at any step undoes restrictions automatically.</summary>
        public bool RestoreOnResolution { get; set; } = true;

        [StringLength(160)]
        public string? UpdatedBy { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;

        public List<CadenceStep> Steps { get; set; } = new();

        public List<CadenceTarget> Targets { get; set; } = new();

        /// <summary>Why this version exists; required once the cadence is active. Stored in the revision.</summary>
        [NotMapped, StringLength(500)]
        public string? ChangeReason { get; set; }
    }
}
