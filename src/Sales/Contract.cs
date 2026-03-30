using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Recurring services
    /// </summary>
    public class Contract
    {
        /// <summary>
        ///     Contract identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Tenant or customer context identifier.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Key for object reference, external id
        /// </summary>
        [StringLength(50)]
        [DefaultValue("")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Key { get; set; } = string.Empty;

        /// <summary>
        ///     Friendly contract title.
        /// </summary>
        public string Title { get; set; } = default!;

        /// <summary>
        ///     Base recurring amount before credits and debits.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        ///     Activation or contract start date.
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        ///     Contract end or cancellation date.
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        ///     Contract lifecycle status.
        /// </summary>
        public ContractStatus Status { get; set; } = ContractStatus.Active;

        /// <summary>
        ///     Preferred strategy for prorating partial periods.
        /// </summary>
        public ContractProrationMode ProrationMode { get; set; } = ContractProrationMode.Daily;

        /// <summary>
        ///     Should charge partial days ?
        /// </summary>
        public bool Partial { get; set; } = true;

        /// <summary>
        ///     Number of months per billing cycle.
        /// </summary>
        public uint BillingCycleMonths { get; set; } = 1;

        /// <summary>
        ///     Preferred due day, overriding customer preferences
        /// </summary>
        public uint? DueDay { get; set; }

        /// <summary>
        ///     Next calculated due date.
        /// </summary>
        public DateTime? NextDueDate { get; set; }

        /// <summary>
        ///     Extra information, observations, etc ...
        /// </summary>
        public string? Extra { get; set; }

        /// <summary>
        ///     UTC creation timestamp.
        /// </summary>
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        /// <summary>
        ///     UTC update timestamp.
        /// </summary>
        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
