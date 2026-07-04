namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Where an inbound WhatsApp call should be routed to, nested under
    /// <see cref="WhatsAppGatewayRouteRequest.Destination"/>.
    /// </summary>
    public class WhatsAppGatewayDestinationRequest
    {
        /// <summary>
        /// Id of the Sufficit destination (extension/queue/IVR), if resolved from a picker.
        /// Informational only; routing uses <see cref="Asterisk"/>.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Asterisk dialplan target the call is sent to (e.g. "sufficit-app-ivr,123,1").
        /// </summary>
        public string? Asterisk { get; set; }

        /// <summary>
        /// Destination type label (e.g. "IVRMenu", "FreePBXDirectCall"), for display only.
        /// </summary>
        public string? Type { get; set; }
    }
}
