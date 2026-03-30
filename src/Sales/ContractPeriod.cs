using System;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Billing period generated for a recurring contract.
    /// </summary>
    public class ContractPeriod
    {
        /// <summary>
        ///     Period identifier.
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
        ///     Inclusive start boundary of the billing period.
        /// </summary>
        public DateTime PeriodStart { get; set; }

        /// <summary>
        ///     Exclusive end boundary of the billing period.
        /// </summary>
        public DateTime PeriodEnd { get; set; }

        /// <summary>
        ///     Due date associated with the period.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        ///     Full recurring amount before proration and credits.
        /// </summary>
        public decimal BaseAmount { get; set; }

        /// <summary>
        ///     Amount after proration by active days, before interruption credits.
        /// </summary>
        public decimal ProratedAmount { get; set; }

        /// <summary>
        ///     Total credited amount for interruptions and non-billable days.
        /// </summary>
        public decimal CreditedAmount { get; set; }

        /// <summary>
        ///     Total debited amount manually or automatically added to the period.
        /// </summary>
        public decimal DebitedAmount { get; set; }

        /// <summary>
        ///     Final billable amount for the period.
        /// </summary>
        public decimal BillableAmount { get; set; }

        /// <summary>
        ///     Total days in the billing period.
        /// </summary>
        public int TotalDays { get; set; }

        /// <summary>
        ///     Days where the contract was effectively active during the period.
        /// </summary>
        public int ActiveDays { get; set; }

        /// <summary>
        ///     Days credited due to interruptions or non-billable intervals.
        /// </summary>
        public int CreditedDays { get; set; }

        /// <summary>
        ///     Active days that remain billable after credits.
        /// </summary>
        public int BillableDays { get; set; }

        /// <summary>
        ///     Period workflow status.
        /// </summary>
        public ContractPeriodStatus Status { get; set; }

        /// <summary>
        ///     Human-readable or serialized summary for diagnostics.
        /// </summary>
        public string? Summary { get; set; }

        /// <summary>
        ///     UTC creation timestamp.
        /// </summary>
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        /// <summary>
        ///     UTC timestamp when the period was closed.
        /// </summary>
        public DateTime? ClosedAtUtc { get; set; }
    }
}
