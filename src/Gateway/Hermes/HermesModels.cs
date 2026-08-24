using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.Hermes
{
    public sealed class HermesContextsResponse
    {
        public HermesContextItem[] Contexts { get; set; } = Array.Empty<HermesContextItem>();
    }

    public sealed class HermesContextItem
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("sip_server")]
        public string SipServer { get; set; } = string.Empty;

        [JsonPropertyName("sip_port")]
        public int SipPort { get; set; }

        [JsonPropertyName("sip_transport")]
        public string SipTransport { get; set; } = string.Empty;

        [JsonPropertyName("sip_realm")]
        public string SipRealm { get; set; } = string.Empty;

        [JsonPropertyName("registration_mode")]
        public string RegistrationMode { get; set; } = "per_agent";

        [JsonPropertyName("inbox_name")]
        public string InboxName { get; set; } = string.Empty;
    }

    public sealed class HermesExtensionsResponse
    {
        public HermesExtensionItem[] Extensions { get; set; } = Array.Empty<HermesExtensionItem>();
    }

    public sealed class HermesExtensionItem
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("extension")]
        public string? Extension { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string? Password { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("context_id")]
        public Guid ContextId { get; set; }
    }
}
