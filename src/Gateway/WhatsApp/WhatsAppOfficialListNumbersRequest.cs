using System;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Lists every WhatsApp Official phone number a token can see — used to feed autocomplete
    /// suggestions for the "manual" connect flow, instead of asking the client to type/paste both
    /// the number and the Phone Number ID from memory.
    /// </summary>
    public class WhatsAppOfficialListNumbersRequest
    {
        public Guid ContextId { get; set; }

        /// <summary>
        /// Required. The client's own token (e.g. a System User token from their Business
        /// Settings) — this is never Sufficit's own fixed token, since that one already knows its
        /// numbers through our persisted routes.
        /// </summary>
        public string AccessToken { get; set; } = string.Empty;
    }
}
