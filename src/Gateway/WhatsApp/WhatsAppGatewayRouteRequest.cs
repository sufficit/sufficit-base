using System;

namespace Sufficit.Gateway.WhatsApp
{
    public class WhatsAppGatewayRouteRequest
    {
        public string? SectionId { get; set; }

        public Guid ContextId { get; set; }

        public bool Enabled { get; set; } = true;

        public WhatsAppGatewayDestinationRequest? Destination { get; set; }

        public WhatsAppGatewaySessionRequest? WhatsApp { get; set; }

        public WhatsAppGatewayRouteOptionsRequest? Options { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
