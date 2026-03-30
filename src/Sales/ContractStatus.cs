namespace Sufficit.Sales
{
    /// <summary>
    ///     Lifecycle status for a recurring contract.
    /// </summary>
    public enum ContractStatus : byte
    {
        /// <summary>
        ///     Contract is not yet active.
        /// </summary>
        Draft = 0,

        /// <summary>
        ///     Contract is active and can generate billing periods.
        /// </summary>
        Active = 1,

        /// <summary>
        ///     Contract is paused by business decision.
        /// </summary>
        Paused = 2,

        /// <summary>
        ///     Contract is suspended, usually by administrative or financial reason.
        /// </summary>
        Suspended = 3,

        /// <summary>
        ///     Contract was canceled and should not generate new periods.
        /// </summary>
        Canceled = 4,

        /// <summary>
        ///     Contract naturally expired.
        /// </summary>
        Expired = 5,
    }
}
