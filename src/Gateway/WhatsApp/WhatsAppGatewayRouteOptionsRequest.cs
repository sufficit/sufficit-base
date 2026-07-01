namespace Sufficit.Gateway.WhatsApp
{
    public class WhatsAppGatewayRouteOptionsRequest
    {
        public string? Mode { get; set; }

        public string? CallMode { get; set; }

        public string? Description { get; set; }

        public string? Filter { get; set; }

        public string? Tags { get; set; }

        public int? MaxChannels { get; set; }

        public string? Notes { get; set; }
    }
}
