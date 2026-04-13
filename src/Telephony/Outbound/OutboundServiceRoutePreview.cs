using System;
using System.Collections.Generic;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Non-persisted preview of the outbound route that telephony would attempt to use.
    /// </summary>
    /// <remarks>
    ///     TODO: merge this preview with recurring-service authorization data once telephony projections are materialized.
    /// </remarks>
    public class OutboundServiceRoutePreview
    {
        /// <summary>
        ///     Customer context evaluated by the preview.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Canonical service identifier requested by the preview, when available.
        /// </summary>
        public Guid? ServiceId { get; set; }

        /// <summary>
        ///     Human-readable title of the resolved canonical service.
        /// </summary>
        public string? ServiceTitle { get; set; }

        /// <summary>
        ///     Requested outbound service type.
        /// </summary>
        public OutboundServiceType ServiceType { get; set; } = OutboundServiceType.UNKNOWN;

        /// <summary>
        ///     Identity policy selected for the request.
        /// </summary>
        public OutboundIdentityPolicy IdentityPolicy { get; set; } = OutboundIdentityPolicy.DEFAULT;

        /// <summary>
        ///     Effective policy used by the preview.
        /// </summary>
        public OutboundServiceEffectivePolicy Policy { get; set; } = new OutboundServiceEffectivePolicy();

        /// <summary>
        ///     Active customer-service entitlement selected for the preview.
        /// </summary>
        public Guid? CustomerServiceId { get; set; }

        /// <summary>
        ///     Explicit ordered source selected for the preview, when available.
        /// </summary>
        public Guid? RouteSourceId { get; set; }

        /// <summary>
        ///     Assignment that contributed to the preview, when present.
        /// </summary>
        public Guid? AssignmentId { get; set; }

        /// <summary>
        ///     Named route profile chosen for the preview.
        /// </summary>
        public string? RouteProfile { get; set; }

        /// <summary>
        ///     Canonical interconnection chosen for the preview, when available.
        /// </summary>
        public Guid? InterconnectionId { get; set; }

        /// <summary>
        ///     Human-readable title of the chosen canonical interconnection.
        /// </summary>
        public string? InterconnectionTitle { get; set; }

        /// <summary>
        ///     Optional canonical DID identifier selected for caller ID.
        /// </summary>
        public Guid? SelectedDidId { get; set; }

        /// <summary>
        ///     Caller ID number selected for the route preview.
        /// </summary>
        public string? SelectedDidNumber { get; set; }

        /// <summary>
        ///     Destination class inferred for the preview request.
        /// </summary>
        public string? DestinationClass { get; set; }

        /// <summary>
        ///     Imported legacy route rule selected for the preview, when available.
        /// </summary>
        public Guid? SelectedRouteRuleId { get; set; }

        /// <summary>
        ///     Match mode of the imported legacy route selected for the preview.
        /// </summary>
        public OutboundRouteRuleMatchMode? SelectedRouteMatchMode { get; set; }

        /// <summary>
        ///     Provider requirement declared by the selected imported route.
        /// </summary>
        public Guid? SelectedRouteProviderId { get; set; }

        /// <summary>
        ///     Server scope declared by the selected imported route.
        /// </summary>
        public string? SelectedRouteServers { get; set; }

        /// <summary>
        ///     Transformed digits that would be sent to the chosen endpoint.
        /// </summary>
        public string? DialedDigits { get; set; }

        /// <summary>
        ///     Host selected for the route preview.
        /// </summary>
        public string? SelectedHost { get; set; }

        /// <summary>
        ///     Port selected for the route preview.
        /// </summary>
        public int? SelectedPort { get; set; }

        /// <summary>
        ///     Endpoint or route profile identifier chosen for dialing.
        /// </summary>
        public string? SelectedEndpoint { get; set; }

        /// <summary>
        ///     Signaling technology chosen for the dial string.
        /// </summary>
        public string? Technology { get; set; }

        /// <summary>
        ///     Timeout that should be passed to the legacy Dial application.
        /// </summary>
        public int DialTimeout { get; set; } = 30;

        /// <summary>
        ///     Dial options compatible with the legacy outbound dialplan.
        /// </summary>
        public string? DialOptions { get; set; }

        /// <summary>
        ///     Optional dial URL argument compatible with the legacy outbound dialplan.
        /// </summary>
        public string? DialUrl { get; set; }

        /// <summary>
        ///     Dial string that would be attempted by the current preview.
        /// </summary>
        public string? DialString { get; set; }

        /// <summary>
        ///     Indicates that the preview had to degrade because the fast cache was unavailable.
        /// </summary>
        public bool CacheDegradedMode { get; set; }

        /// <summary>
        ///     Zero-based attempt index requested by the caller.
        /// </summary>
        public int AttemptIndex { get; set; }

        /// <summary>
        ///     Total number of dial candidates compatible with the current preview.
        /// </summary>
        public int TotalCandidates { get; set; }

        /// <summary>
        ///     Human-readable notes and caveats emitted during the preview.
        /// </summary>
        public ICollection<string> Notes { get; set; } = new List<string>();
    }
}

