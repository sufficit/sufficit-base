using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.MagnusBilling
{
    /// <summary>
    /// MagnusBilling API Key entity for authentication
    /// Supports multi-tenant access to multiple Sufficit contexts
    /// </summary>
    public class MagnusBillingApiKey
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("api_key")]
        public string ApiKey { get; set; } = string.Empty;

        [JsonPropertyName("api_secret")]
        public string ApiSecret { get; set; } = string.Empty;

        [JsonPropertyName("context_id")]
        public string ContextId { get; set; } = string.Empty;

        [JsonPropertyName("user_id")]
        public string UserId { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("permissions")]
        public string[] Permissions { get; set; } = Array.Empty<string>();

        [JsonPropertyName("entity_mappings")]
        public MagnusBillingEntityMapping[] EntityMappings { get; set; } = Array.Empty<MagnusBillingEntityMapping>();

        [JsonPropertyName("active")]
        public bool Active { get; set; } = true;

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("expires_at")]
        public DateTime? ExpiresAt { get; set; }

        [JsonPropertyName("last_used_at")]
        public DateTime? LastUsedAt { get; set; }

        [JsonPropertyName("last_used_ip")]
        public string? LastUsedIp { get; set; }

        /// <summary>
        /// Contexts that this API key has access to
        /// </summary>
        [JsonPropertyName("contexts")]
        public Guid[] AllowedContexts { get; set; } = Array.Empty<Guid>();
    }
}