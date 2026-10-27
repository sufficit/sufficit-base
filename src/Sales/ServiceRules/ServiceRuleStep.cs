using System;
using System.ComponentModel.DataAnnotations;

namespace Sufficit.Sales
{
    /// <summary>One milestone of a schedule: at <see cref="OffsetDays"/> from the due date, request an action.</summary>
    public sealed class ServiceRuleStep
    {
        public Guid Id { get; set; }

        public Guid RuleId { get; set; }

        /// <summary>Days relative to the due date: -3 = three days before, 0 = due date, 5 = five days after.</summary>
        public int OffsetDays { get; set; }

        /// <summary>Tie-breaker for steps on the same day.</summary>
        public int Order { get; set; }

        /// <summary>Key from <see cref="ServiceRuleActions"/>.</summary>
        [Required, StringLength(64)]
        public string Action { get; set; } = string.Empty;

        public ServiceRuleAudience Audience { get; set; }

        /// <summary>Comma separated channels for messages (whatsapp, email, sms).</summary>
        [StringLength(120)]
        public string? Channels { get; set; }

        /// <summary>Optional key from <see cref="ServiceRuleConditions"/>.</summary>
        [StringLength(64)]
        public string? Condition { get; set; }

        [StringLength(250)]
        public string? Note { get; set; }
    }
}
