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
        /// Quepasa's persisted database id (UUIDv7) for this session — stable across phone number
        /// swaps within the same session. This is what Quepasa now sends over SIP as
        /// X-QuePasa-SessionId (see quepasa commit "fix(voip): never send the connection token
        /// over SIP, use session id instead") and what must be saved into
        /// <see cref="WhatsAppGatewayRoute.SessionId"/> for Quepasa routes going forward — the
        /// connection token is a credential and is never sent on the wire anymore.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Quepasa's raw WhatsApp-native identifier ("phone:index@domain"), kept verbatim for
        /// display/debugging. NOT the routing key — that's <see cref="Id"/> now. Not reliably
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
