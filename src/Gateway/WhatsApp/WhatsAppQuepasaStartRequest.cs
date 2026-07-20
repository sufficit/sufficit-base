using System;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Starts (or resumes) a Quepasa (unofficial WhatsApp) pairing session for a context.
    /// </summary>
    public class WhatsAppQuepasaStartRequest
    {
        public Guid ContextId { get; set; }

        /// <summary>
        /// "qrcode" (default) or "paircode". Paircode requires <see cref="Phone"/>.
        /// </summary>
        public string Mode { get; set; } = "qrcode";

        /// <summary>
        /// Required when <see cref="Mode"/> is "paircode" — E.164 digits of the WhatsApp number
        /// being paired.
        /// </summary>
        public string? Phone { get; set; }
    }
}
