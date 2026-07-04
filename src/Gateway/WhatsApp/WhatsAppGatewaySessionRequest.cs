namespace Sufficit.Gateway.WhatsApp
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Provider-specific identity of a WhatsApp gateway route, nested under
    /// <see cref="WhatsAppGatewayRouteRequest.WhatsApp"/>.
    /// </summary>
    public class WhatsAppGatewaySessionRequest
    {
        /// <summary>
        /// Session/route key. Used as the top-level request's session id when that one is omitted.
        /// </summary>
        public string? SessionId { get; set; }

        /// <summary>
        /// Provider auth token, when applicable.
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// Meta Cloud API phone_number_id. Used as a last-resort fallback for the session id
        /// when neither <see cref="SessionId"/> nor the request's top-level SessionId is set.
        /// </summary>
        [JsonPropertyName("whatsappid")]
        public string? WhatsAppId { get; set; }

        /// <summary>
        /// Phone number for display, normalized to E.164 ("+"-prefixed) on save.
        /// </summary>
        public string? Phone { get; set; }
    }
}
