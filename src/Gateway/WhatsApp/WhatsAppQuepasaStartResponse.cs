namespace Sufficit.Gateway.WhatsApp
{
    public class WhatsAppQuepasaStartResponse
    {
        /// <summary>
        /// The Quepasa session token — save this as the route's SessionId/Token in step 2.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Present when qrcode mode was used — a data: URI (image/png) ready for an &lt;img&gt; tag.
        /// </summary>
        public string? QrCodeBase64 { get; set; }

        /// <summary>
        /// Present when paircode mode was used — the 8-character code to type into WhatsApp.
        /// </summary>
        public string? PairCode { get; set; }
    }
}
