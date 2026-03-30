using System;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Search filters for contract interruptions.
    /// </summary>
    public class ContractInterruptionSearchParameters : ILimit
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
        ///     Interruption type filter.
        /// </summary>
        public ContractInterruptionType? Type { get; set; }

        /// <summary>
        ///     Date range filter applied to interruption intervals.
        /// </summary>
        public DateTimeRange? Period { get; set; }

        /// <summary>
        ///     Filters only currently active or inactive interruptions.
        /// </summary>
        public bool? Active { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        public uint? Limit { get; set; }
    }
}
