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
        ///     Assignment that contributed to the preview, when present.
        /// </summary>
        public Guid? AssignmentId { get; set; }

        /// <summary>
        ///     Named route profile chosen for the preview.
        /// </summary>
        public string? RouteProfile { get; set; }

        /// <summary>
        ///     Customer trunk chosen for BYOC routes.
        /// </summary>
        public Guid? CustomerTrunkId { get; set; }

        /// <summary>
        ///     Human-readable title of the chosen customer trunk.
        /// </summary>
        public string? CustomerTrunkTitle { get; set; }

        /// <summary>
        ///     Optional canonical DID identifier selected for caller ID.
        /// </summary>
        public Guid? SelectedDidId { get; set; }

        /// <summary>
        ///     Caller ID number selected for the route preview.
        /// </summary>
        public string? SelectedDidNumber { get; set; }

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
        ///     Dial string that would be attempted by the current preview.
        /// </summary>
        public string? DialString { get; set; }

        /// <summary>
        ///     Indicates that the preview had to degrade because the fast cache was unavailable.
        /// </summary>
        public bool CacheDegradedMode { get; set; }

        /// <summary>
        ///     Human-readable notes and caveats emitted during the preview.
        /// </summary>
        public ICollection<string> Notes { get; set; } = new List<string>();
    }
}
