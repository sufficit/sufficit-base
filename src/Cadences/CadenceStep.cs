using System;
using System.ComponentModel.DataAnnotations;

namespace Sufficit.Cadences
{
    /// <summary>One milestone: at <see cref="OffsetDays"/> from the anchor date, request an action.</summary>
    public sealed class CadenceStep
    {
        public Guid Id { get; set; }

        public Guid CadenceId { get; set; }

        /// <summary>Days relative to the anchor: -3 = three days before, 0 = on the day, 5 = five days after.</summary>
        public int OffsetDays { get; set; }

        /// <summary>Tie-breaker for steps on the same day.</summary>
        public int Order { get; set; }

        /// <summary>Key from <see cref="CadenceActions"/>.</summary>
        [Required, StringLength(64)]
        public string Action { get; set; } = string.Empty;

        public CadenceAudience Audience { get; set; }

        /// <summary>Comma separated channels for messages (whatsapp, email, sms).</summary>
        [StringLength(120)]
        public string? Channels { get; set; }

        /// <summary>Optional fact from <see cref="CadenceConditions"/> that skips this step.</summary>
        [StringLength(64)]
        public string? Condition { get; set; }

        /// <summary>Action-specific value (e.g. notification template title); see <see cref="CadenceActionDefinition.ParametersLabel"/>.</summary>
        [StringLength(500)]
        public string? Parameters { get; set; }

        [StringLength(250)]
        public string? Note { get; set; }
    }
}
