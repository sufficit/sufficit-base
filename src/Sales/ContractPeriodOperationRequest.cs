using System;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Request payload for manager-level operations over a recurring billing period.
    /// </summary>
    public sealed class ContractPeriodOperationRequest
    {
        /// <summary>
        ///     Target period identifier.
        /// </summary>
        public Guid PeriodId { get; set; }

        /// <summary>
        ///     Mandatory operator reason describing why the action is being forced.
        /// </summary>
        public string? Reason { get; set; }
    }
}
