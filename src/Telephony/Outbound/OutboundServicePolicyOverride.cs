using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Manager-controlled override applied on top of the default outbound policy for one customer context.
    /// </summary>
    public class OutboundServicePolicyOverride
    {
        /// <summary>
        ///     Unique identifier of the override row.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Customer context affected by the override.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Service type whose policy is being overridden.
        /// </summary>
        public OutboundServiceType ServiceType { get; set; } = OutboundServiceType.UNKNOWN;

        /// <summary>
        ///     Optional explicit channel limit override.
        /// </summary>
        public int? ChannelLimitOverride { get; set; }

        /// <summary>
        ///     Optional explicit request limit override.
        /// </summary>
        public int? RequestLimitOverride { get; set; }

        /// <summary>
        ///     Optional explicit request window override in hours.
        /// </summary>
        public int? RequestWindowHoursOverride { get; set; }

        /// <summary>
        ///     Optional explicit fail-open override.
        /// </summary>
        public bool? FailOpenOnBillingErrorOverride { get; set; }

        /// <summary>
        ///     Indicates whether the override may be used.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        ///     Free-form rationale stored by the operator.
        /// </summary>
        public string? Comments { get; set; }

        /// <summary>
        ///     Last operator that changed the override.
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        ///     Last update timestamp in UTC.
        /// </summary>
        public DateTime UpdatedAtUtc { get; set; }
    }
}
