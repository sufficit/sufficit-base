using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Versioned schedule ("régua") of steps relative to a contract due date. Stored in the database and bound to
    ///     catalog items (optionally overridden per contract); workers and consumer systems read it, nothing is hardcoded.
    /// </summary>
    public sealed class ServiceRule
    {
        public Guid Id { get; set; }

        [Required, StringLength(160)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ServiceRuleKind Kind { get; set; } = ServiceRuleKind.CutOff;

        public ServiceRuleStatus Status { get; set; } = ServiceRuleStatus.Draft;

        /// <summary>Incremented on every save; executions record the version they followed.</summary>
        public int Version { get; set; }

        /// <summary>Payment at any step restores the service automatically.</summary>
        public bool ReactivateOnPayment { get; set; } = true;

        [StringLength(160)]
        public string? UpdatedBy { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;

        public List<ServiceRuleStep> Steps { get; set; } = new();

        public List<ServiceRuleBinding> Bindings { get; set; } = new();

        /// <summary>Why this version exists; required once the schedule is active. Stored in the revision.</summary>
        [NotMapped, StringLength(500)]
        public string? ChangeReason { get; set; }
    }
}
