using System;

namespace Sufficit.Sales.Events
{
    /// <summary>
    ///     Extends telephony service events with prepaid coverage or balance information.
    /// </summary>
    public interface ITelephonyServiceCoverageEvent : ITelephonyServiceContractEvent
    {
        /// <summary>
        ///     Coverage amount granted or removed by the event.
        /// </summary>
        decimal? CoverageAmount { get; }

        /// <summary>
        ///     Remaining balance or coverage after the event was applied.
        /// </summary>
        decimal? AvailableAmount { get; }

        /// <summary>
        ///     Unit associated with the coverage amount, such as BRL, minute, or credit.
        /// </summary>
        string? CoverageUnit { get; }
    }
}
