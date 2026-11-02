using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>Softphone diagnostics posted to <c>POST /Telephony/ChromeExtension/Telemetry</c>.</summary>
    public sealed class ChromeExtensionTelemetryRequest
    {
        [JsonPropertyName("version")]
        public string? Version { get; set; }

        [JsonPropertyName("browser")]
        public string? Browser { get; set; }

        [JsonPropertyName("events")]
        public List<ChromeExtensionTelemetryEvent> Events { get; set; } = new List<ChromeExtensionTelemetryEvent>();
    }

    public sealed class ChromeExtensionTelemetryEvent
    {
        /// <summary>Client id of the event, used as reference (idempotent resend).</summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>Unix milliseconds when it happened on the client.</summary>
        [JsonPropertyName("at")]
        public long? At { get; set; }

        [JsonPropertyName("detail")]
        public Dictionary<string, JsonElement>? Detail { get; set; }
    }

    public sealed class ChromeExtensionTelemetryResponse
    {
        [JsonPropertyName("accepted")]
        public int Accepted { get; set; }
    }
}
