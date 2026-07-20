namespace Sufficit.Gateway.WhatsApp
{
    public class WhatsAppQuepasaStatusResponse
    {
        /// <summary>
        /// True once the WhatsApp number has actually scanned the QR code / accepted the pair
        /// code and the Quepasa session reports a verified connection.
        /// </summary>
        public bool Connected { get; set; }

        /// <summary>
        /// The paired number's digits (E.164, no +), once <see cref="Connected"/> is true. Our own
        /// resolved value for display — derived from <see cref="Wid"/> but kept as a separate
        /// field on purpose (see <see cref="WhatsAppGatewayRoute.Phone"/>).
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Quepasa's raw session identifier ("phone:index@domain"), kept verbatim — save this into
        /// <see cref="WhatsAppGatewayRoute.WhatsAppId"/>, never into Phone/SessionId. Not reliably
        /// reducible to a phone number (the ":index" suffix isn't part of the number).
        /// </summary>
        public string? Wid { get; set; }

        /// <summary>
        /// Raw whatsmeow/Quepasa connection state string (e.g. "Ready", "Connected",
        /// "UnVerified", "Connecting", "Disconnected", "Failed") — lets the UI show a live status
        /// without the admin having to re-open the connect wizard just to check.
        /// </summary>
        public string? State { get; set; }
    }
}
