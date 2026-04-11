using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Request payload used to simulate outbound route selection.
    /// </summary>
    public class OutboundServiceRoutePreviewRequest
    {
        /// <summary>
        ///     Customer context that is requesting the route.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Optional canonical service identifier being evaluated.
        /// </summary>
        public Guid? ServiceId { get; set; }

        /// <summary>
        ///     Outbound service type being evaluated.
        /// </summary>
        public OutboundServiceType ServiceType { get; set; } = OutboundServiceType.UNKNOWN;

        /// <summary>
        ///     Optional explicit ordered route source to preview.
        /// </summary>
        public Guid? RouteSourceId { get; set; }

        /// <summary>
        ///     Optional explicit assignment to preview.
        /// </summary>
        public Guid? AssignmentId { get; set; }

        /// <summary>
        ///     Destination number to be routed.
        /// </summary>
        public string Destination { get; set; } = string.Empty;

        /// <summary>
        ///     Optional caller ID number used to simulate identified legacy routes and national dial transforms.
        /// </summary>
        public string? CallerIdNumber { get; set; }

        /// <summary>
        ///     Optional caller DID provider used to simulate CLI_PROVIDER legacy routes.
        /// </summary>
        public Guid? ProviderId { get; set; }

        /// <summary>
        ///     Optional explicit legacy identified/non-identified decision.
        /// </summary>
        public bool? LegacyIdentified { get; set; }

        /// <summary>
        ///     Optional preferred server or cluster hint.
        /// </summary>
        public string? Server { get; set; }

        /// <summary>
        ///     Optional endpoint hint used by future routing logic.
        /// </summary>
        public Guid? EndPointId { get; set; }
    }
}
