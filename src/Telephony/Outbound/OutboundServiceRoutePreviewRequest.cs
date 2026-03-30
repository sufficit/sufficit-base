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
        ///     Outbound service type being evaluated.
        /// </summary>
        public OutboundServiceType ServiceType { get; set; } = OutboundServiceType.UNKNOWN;

        /// <summary>
        ///     Optional explicit assignment to preview.
        /// </summary>
        public Guid? AssignmentId { get; set; }

        /// <summary>
        ///     Destination number to be routed.
        /// </summary>
        public string Destination { get; set; } = string.Empty;

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
