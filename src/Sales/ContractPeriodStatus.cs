namespace Sufficit.Sales
{
    /// <summary>
    ///     Status for a generated billing period.
    /// </summary>
    public enum ContractPeriodStatus : byte
    {
        /// <summary>
        ///     Period was generated for future billing.
        /// </summary>
        Projected = 0,

        /// <summary>
        ///     Period is currently open or in progress.
        /// </summary>
        Open = 1,

        /// <summary>
        ///     Period is closed and should no longer change.
        /// </summary>
        Closed = 2,
    }
}
