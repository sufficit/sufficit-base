using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// SIP configuration returned by <c>GET /Telephony/ChromeExtension/Config</c>.
    /// Consumed by the Chrome softphone extension to register and operate.
    /// </summary>
    public class ChromeExtensionConfig
    {
        [JsonPropertyName("extension")]
        [JsonPropertyOrder(1)]
        public string Extension { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        [JsonPropertyOrder(2)]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("displayName")]
        [JsonPropertyOrder(3)]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("aor")]
        [JsonPropertyOrder(4)]
        public string Aor { get; set; } = string.Empty;

        [JsonPropertyName("userId")]
        [JsonPropertyOrder(5)]
        public Guid UserId { get; set; }

        [JsonPropertyName("server")]
        [JsonPropertyOrder(6)]
        public string[] Server { get; set; } = Array.Empty<string>();

        [JsonPropertyName("setupUrl")]
        [JsonPropertyOrder(7)]
        public string SetupUrl { get; set; } = string.Empty;

        /// <summary>
        /// Optional runtime parameters for SIP client behavior.
        /// Clients should fall back to their own defaults if absent or invalid.
        /// </summary>
        [JsonPropertyName("sipRuntime")]
        [JsonPropertyOrder(10)]
        public SipRuntimeConfig? SipRuntime { get; set; }
    }
}
