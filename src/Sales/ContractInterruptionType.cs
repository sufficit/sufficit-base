namespace Sufficit.Sales
{
    /// <summary>
    ///     Semantic type of an interruption registered against a contract.
    /// </summary>
    public enum ContractInterruptionType : byte
    {
        /// <summary>
        ///     Pause requested for the service.
        /// </summary>
        Pause = 0,

        /// <summary>
        ///     Suspension by financial or administrative reason.
        /// </summary>
        Suspension = 1,

        /// <summary>
        ///     Operational interruption or outage.
        /// </summary>
        Interruption = 2,

        /// <summary>
        ///     Planned maintenance interval.
        /// </summary>
        Maintenance = 3,
    }
}
