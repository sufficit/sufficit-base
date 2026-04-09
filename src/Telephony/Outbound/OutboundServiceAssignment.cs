using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Outbound routing assignment for a specific customer context and service type.
    /// </summary>
    /// <remarks>
    ///     TODO: replace manual assignment maintenance with telephony-side projections fed by recurring service events.
    /// </remarks>
    public class OutboundServiceAssignment
    {
        /// <summary>
        ///     Unique identifier of the assignment row.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Customer context that owns the outbound rule.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Outbound product family resolved by this assignment.
        /// </summary>
        public OutboundServiceType ServiceType { get; set; } = OutboundServiceType.UNKNOWN;

        /// <summary>
        ///     Indicates whether the assignment may be considered during route preview.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        ///     Lower values win when multiple assignments exist for the same service type.
        /// </summary>
        public int Priority { get; set; } = 100;

        /// <summary>
        ///     Optional per-assignment channel cap.
        /// </summary>
        public int? ChannelLimit { get; set; }

        /// <summary>
        ///     Optional per-assignment request limit for fair-usage style services.
        /// </summary>
        public int? RequestLimit { get; set; }

        /// <summary>
        ///     Optional request window in hours used together with <see cref="RequestLimit"/>.
        /// </summary>
        public int? RequestWindowHours { get; set; }

        /// <summary>
        ///     Original legacy trunk title when this row was imported from the old outbound catalog.
        /// </summary>
        public string? LegacySourceTitle { get; set; }

        /// <summary>
        ///     Destination scope resolved from the legacy catalog, such as FIXED, MOBILE or FIXED,MOBILE.
        /// </summary>
        public string? DestinationScope { get; set; }

        /// <summary>
        ///     Indicates that the service requires balance validation before the call is allowed.
        /// </summary>
        public bool RequireBalanceCheck { get; set; }

        /// <summary>
        ///     Indicates that the service is used as a fallback bucket in the legacy selection tree.
        /// </summary>
        public bool IsFallback { get; set; }

        /// <summary>
        ///     Named realtime route profile used by non-BYOC routes.
        /// </summary>
        public string? RouteProfile { get; set; }

        /// <summary>
        ///     Indicates whether the imported legacy runtime semantics diverge from static documentation comments.
        /// </summary>
        public bool HasLegacyRuntimeMismatch { get; set; }

        /// <summary>
        ///     Calling identity policy requested by this assignment.
        /// </summary>
        public OutboundIdentityPolicy IdentityPolicy { get; set; } = OutboundIdentityPolicy.DEFAULT;

        /// <summary>
        ///     Optional default DID to expose when the policy needs a fixed identity.
        /// </summary>
        public Guid? DefaultDidId { get; set; }

        /// <summary>
        ///     Optional canonical interconnection used by this assignment.
        ///     This is the preferred isolation path because the same interconnection
        ///     record may serve inbound, outbound, or both directions.
        /// </summary>
        public Guid? InterconnectionId { get; set; }

        /// <summary>
        ///     Free-form operator notes.
        /// </summary>
        public string? Comments { get; set; }

        /// <summary>
        ///     Creation timestamp in UTC.
        /// </summary>
        public DateTime CreatedAtUtc { get; set; }

        /// <summary>
        ///     Last update timestamp in UTC.
        /// </summary>
        public DateTime? UpdatedAtUtc { get; set; }
    }
}
