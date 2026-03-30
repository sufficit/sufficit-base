using System;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Financial adjustment generated or applied to a contract period.
    /// </summary>
    public class ContractAdjustment
    {
        /// <summary>
        ///     Adjustment identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Parent contract identifier.
        /// </summary>
        public Guid ContractId { get; set; }

        /// <summary>
        ///     Tenant or customer context identifier.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Billing period related to the adjustment.
        /// </summary>
        public Guid? PeriodId { get; set; }

        /// <summary>
        ///     Interruption that originated the adjustment, when applicable.
        /// </summary>
        public Guid? InterruptionId { get; set; }

        /// <summary>
        ///     Adjustment semantic type.
        /// </summary>
        public ContractAdjustmentType Type { get; set; }

        /// <summary>
        ///     Monetary amount of the adjustment.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        ///     Number of days represented by the adjustment.
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        ///     Readable explanation for the adjustment.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        ///     Optional external or diagnostic reference.
        /// </summary>
        public string? Reference { get; set; }

        /// <summary>
        ///     UTC creation timestamp.
        /// </summary>
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
