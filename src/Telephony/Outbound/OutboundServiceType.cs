namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     High-level outbound service families used by telephony.
    ///     The numeric order reflects the default internal Sufficit precedence.
    /// </summary>
    public enum OutboundServiceType : uint
    {
        /// <summary>
        ///     Unknown or not yet classified outbound service.
        /// </summary>
        UNKNOWN = 0,

        /// <summary>
        ///     Unlimited fixed service; highest internal precedence.
        /// </summary>
        FIXED_UNLIMITED = 10,

        /// <summary>
        ///     Unlimited mobile service; evaluated after unlimited fixed.
        /// </summary>
        MOBILE_UNLIMITED = 20,

        /// <summary>
        ///     Identified single service; preferred over flexible service.
        /// </summary>
        SINGLE = 30,

        /// <summary>
        ///     Flexible Sufficit service bucket, including FLEX and FLEX+.
        /// </summary>
        FLEX = 40,

        /// <summary>
        ///     Metered fallback service backed by billing balances.
        /// </summary>
        BILLED = 50,

        /// <summary>
        ///     Last-resort free fallback service.
        /// </summary>
        FREE = 60,

        /// <summary>
        ///     Legacy smart routing using customer-owned CLI pools.
        /// </summary>
        SMART_CUSTOMER = 70,

        /// <summary>
        ///     Legacy smart routing using shared global CLI pools.
        /// </summary>
        SMART_GLOBAL = 80,

        /// <summary>
        ///     Bring-your-own-carrier routing.
        /// </summary>
        BYOC = 90
    }
}
