using System;
using System.ComponentModel.DataAnnotations;

namespace Sufficit.Cadences
{
    /// <summary>One milestone of a cadence: at <see cref="OffsetDays"/> from D0, the event with <see cref="Key"/> is emitted.</summary>
    public sealed class CadenceMilestone
    {
        public Guid Id { get; set; }

        public Guid CadenceId { get; set; }

        /// <summary>Key from the milestone catalog, contributed by a module (<see cref="ICadenceMilestoneSource"/>).</summary>
        [Required, StringLength(96)]
        public string Key { get; set; } = string.Empty;

        /// <summary>Days relative to D0: -3 = three days before, 0 = on the day, 5 = five days after.</summary>
        public int OffsetDays { get; set; }

        /// <summary>Tie-breaker for milestones on the same day.</summary>
        public int Order { get; set; }

        [StringLength(250)]
        public string? Note { get; set; }
    }
}
