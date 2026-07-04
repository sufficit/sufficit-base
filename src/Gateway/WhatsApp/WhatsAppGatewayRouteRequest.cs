using System;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Create/update payload for a WhatsApp gateway route. Maps to <see cref="WhatsAppGatewayRoute"/>
    /// via WhatsAppGatewayRuntime.BuildRoute.
    /// </summary>
    public class WhatsAppGatewayRouteRequest
    {
        /// <summary>
        /// Optional. Explicit session id (route key). If omitted, falls back to
        /// <see cref="WhatsAppGatewaySessionRequest.SessionId"/> then <see cref="WhatsAppGatewaySessionRequest.WhatsAppId"/>.
        /// </summary>
        public string? SessionId { get; set; }

        /// <summary>
        /// Tenant/context this route belongs to.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        /// Whether the route should route calls immediately after saving.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Where the call should be routed to.
        /// </summary>
        public WhatsAppGatewayDestinationRequest? Destination { get; set; }

        /// <summary>
        /// Provider identity for this route (token, session id, phone number).
        /// </summary>
        public WhatsAppGatewaySessionRequest? WhatsApp { get; set; }

        /// <summary>
        /// Call handling behavior (mode, call mode, filters, tags, limits).
        /// </summary>
        public WhatsAppGatewayRouteOptionsRequest? Options { get; set; }

        /// <summary>
        /// Client-side last-known update timestamp, used for optimistic concurrency checks upstream.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
