namespace Sufficit.Gateway.WhatsApp
{
    using System.Text.Json.Serialization;

    public class WhatsAppGatewaySessionRequest
    {
        public string? Token { get; set; }

        public string? SessionId { get; set; }

        [JsonPropertyName("whatsappid")]
        public string? WhatsAppId { get; set; }

        public string? WhatsAppNumber { get; set; }
    }
}
