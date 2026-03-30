using System;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Search filters for generated contract periods.
    /// </summary>
    public class ContractPeriodSearchParameters : ILimit
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
        ///     Period date range filter.
        /// </summary>
        public DateTimeRange? Period { get; set; }

        /// <summary>
        ///     Period status filter.
        /// </summary>
        public ContractPeriodStatus? Status { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        public uint? Limit { get; set; }
    }
}
