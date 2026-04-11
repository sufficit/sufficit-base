namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Effective outbound policy after combining profile defaults, assignment hints, and manager overrides.
    /// </summary>
    public class OutboundServiceEffectivePolicy
    {
        /// <summary>
        ///     Service type resolved by the policy.
        /// </summary>
        public OutboundServiceType ServiceType { get; set; } = OutboundServiceType.UNKNOWN;

        /// <summary>
        ///     Maximum channels allowed for the route.
        /// </summary>
        public int ChannelLimit { get; set; }

        /// <summary>
        ///     Optional fair-usage request limit.
        /// </summary>
        public int? RequestLimit { get; set; }

        /// <summary>
        ///     Time window, in hours, used with <see cref="RequestLimit"/>.
        /// </summary>
        public int? RequestWindowHours { get; set; }

        /// <summary>
        ///     Whether telephony may fail open when billing data is temporarily unavailable.
        /// </summary>
        public bool FailOpenOnBillingError { get; set; } = true;
    }
}
