using System;

namespace Sufficit.Gateway.QuePasa
{
    public class QuePasaGatewayRouteRequest
    {
        public string? SectionId { get; set; }

        public Guid ContextId { get; set; }

        public bool Enabled { get; set; } = true;

        public QuePasaGatewayDestinationRequest? Destination { get; set; }

        public QuePasaGatewaySessionRequest? QuePasa { get; set; }

        public QuePasaGatewayRouteOptionsRequest? Options { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
