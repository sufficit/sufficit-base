namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Requests a fresh QR code or pairing code for an EXISTING, already-provisioned Quepasa
    /// session (same persisted SessionId) — used to recover a route that disconnected (e.g.
    /// logged out remotely, phone reset) without deleting and re-pairing it from scratch.
    /// </summary>
    public class WhatsAppQuepasaRescanRequest
    {
        /// <summary>
        /// "qrcode" (default) or "paircode". Paircode reuses the route's already-saved phone
        /// number — nothing else to type.
        /// </summary>
        public string Mode { get; set; } = "qrcode";
    }
}
