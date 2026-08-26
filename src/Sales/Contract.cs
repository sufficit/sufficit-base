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
        ///     Optional ERP catalog definition used to create this contract. The
        ///     title and price remain snapshots so historical contracts survive
        ///     catalog retirement or later price changes.
        /// </summary>
        public Guid? CatalogItemId { get; set; }

        /// <summary>
        ///     Values collected according to the selected catalog parameter schema.
        /// </summary>
        public Dictionary<string, string> ParameterValues { get; set; } = new();

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
        ///     Origin of the contract. Legacy imports remain identifiable while the
        ///     old sales system and the new runtime operate side by side.
        /// </summary>
        public ContractSource Source { get; set; } = ContractSource.Native;

        /// <summary>
        ///     Stable source key used by repeatable imports to reconcile renewal
        ///     chains without creating duplicate contracts.
        /// </summary>
        [StringLength(190)]
        public string? SourceKey { get; set; }

        /// <summary>
        ///     Enables future automatic billing/provisioning for this contract.
        ///     Imported contracts remain disabled until the final cutover.
        /// </summary>
        public bool AutomationEnabled { get; set; }

        /// <summary>
        ///     Billing date reported by the source system, when available.
        /// </summary>
        public DateTime? BillingDate { get; set; }

        /// <summary>
        ///     Commercial representative entitled to commission, when applicable.
        /// </summary>
        public Guid? CommissionedId { get; set; }

        /// <summary>
        ///     Commission value or percentage as stored by the source system.
        /// </summary>
        public decimal Commission { get; set; }

        /// <summary>
        ///     Last update timestamp observed in the source system.
        /// </summary>
        public DateTime? SourceUpdatedAtUtc { get; set; }

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
