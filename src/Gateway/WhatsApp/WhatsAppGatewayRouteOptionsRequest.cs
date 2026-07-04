namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Call handling options for a WhatsApp gateway route, nested under
    /// <see cref="WhatsAppGatewayRouteRequest.Options"/>.
    /// </summary>
    public class WhatsAppGatewayRouteOptionsRequest
    {
        /// <summary>
        /// "exclusive" or "parallel". WhatsApp Official is always "exclusive"; Quepasa
        /// is typically "parallel" since it can share the line with other call handling.
        /// </summary>
        public string? Mode { get; set; }

        /// <summary>
        /// How simultaneous/competing calls on the same line are handled (e.g. forward/ignore/deny/allow).
        /// </summary>
        public string? CallMode { get; set; }

        /// <summary>
        /// Any notes that facilitate identification on searches. Falls back to <see cref="Notes"/> if empty.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Regex to restrict allowed source caller ids before routing the call.
        /// </summary>
        public string? Filter { get; set; }

        /// <summary>
        /// Tags or caller id name prefixes used by the telephony routing layer.
        /// </summary>
        public string? Tags { get; set; }

        /// <summary>
        /// Maximum simultaneous channels allowed for this route.
        /// </summary>
        public int? MaxChannels { get; set; }

        /// <summary>
        /// Alternate source for <see cref="Description"/>, used when the client sends notes instead.
        /// </summary>
        public string? Notes { get; set; }
    }
}
