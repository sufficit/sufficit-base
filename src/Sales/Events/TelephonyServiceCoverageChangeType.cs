namespace Sufficit.Sales.Events
{
    /// <summary>
    ///     Coverage and prepaid balance change kinds exposed to telephony consumers.
    /// </summary>
    public enum TelephonyServiceCoverageChangeType : byte
    {
        /// <summary>
        ///     New prepaid coverage or credits were granted.
        /// </summary>
        Granted = 0,

        /// <summary>
        ///     Existing prepaid coverage or validity was extended.
        /// </summary>
        Extended = 1,

        /// <summary>
        ///     Available coverage was reduced by usage or manual action.
        /// </summary>
        Debited = 2,

        /// <summary>
        ///     Available coverage was increased by compensation or manual action.
        /// </summary>
        Credited = 3,

        /// <summary>
        ///     Coverage expired by time or policy.
        /// </summary>
        Expired = 4,

        /// <summary>
        ///     Coverage reached zero and the service may need operational enforcement.
        /// </summary>
        Exhausted = 5,
    }
}
