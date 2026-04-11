using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Default outbound policy profile for one service type.
    /// </summary>
    public class OutboundServicePolicyProfile
    {
        /// <summary>
        ///     Service type described by the profile.
        /// </summary>
        public OutboundServiceType ServiceType { get; set; } = OutboundServiceType.UNKNOWN;

        /// <summary>
        ///     Human-readable title for operators.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        ///     Default channel limit for the service type.
        /// </summary>
        public int? DefaultChannelLimit { get; set; }

        /// <summary>
        ///     Default fair-usage request limit.
        /// </summary>
        public int? DefaultRequestLimit { get; set; }

        /// <summary>
        ///     Default fair-usage request window in hours.
        /// </summary>
        public int? DefaultRequestWindowHours { get; set; }

        /// <summary>
        ///     Default fail-open behavior when billing data is unavailable.
        /// </summary>
        public bool DefaultFailOpenOnBillingError { get; set; } = true;

        /// <summary>
        ///     Indicates whether the profile may be used.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        ///     Last update timestamp in UTC.
        /// </summary>
        public DateTime UpdatedAtUtc { get; set; }
    }
}
