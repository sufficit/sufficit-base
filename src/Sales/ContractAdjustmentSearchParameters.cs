using System;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Search filters for contract billing adjustments.
    /// </summary>
    public class ContractAdjustmentSearchParameters : ILimit
    {
        /// <summary>
        ///     Parent contract identifier filter.
        /// </summary>
        public Guid? ContractId { get; set; }

        /// <summary>
        ///     Tenant or customer context identifier filter.
        /// </summary>
        public Guid? ContextId { get; set; }

        /// <summary>
        ///     Billing period identifier filter.
        /// </summary>
        public Guid? PeriodId { get; set; }

        /// <summary>
        ///     Adjustment type filter.
        /// </summary>
        public ContractAdjustmentType? Type { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        public uint? Limit { get; set; }
    }
}
