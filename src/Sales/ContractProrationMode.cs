namespace Sufficit.Sales
{
    /// <summary>
    ///     Defines how recurring amounts should be prorated.
    /// </summary>
    public enum ContractProrationMode : byte
    {
        /// <summary>
        ///     Do not prorate partial periods.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Prorate using day-based calculation.
        /// </summary>
        Daily = 1,
    }
}
