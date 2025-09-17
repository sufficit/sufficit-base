using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.MagnusBilling
{
    /// <summary>
    /// MagnusBilling API Key Context mapping
    /// Links API keys to Sufficit contexts
    /// </summary>
    public class MagnusBillingApiKeyContext
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("api_key_id")]
        public Guid ApiKeyId { get; set; }

        [JsonPropertyName("context_id")]
        public Guid ContextId { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; } = true;

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}