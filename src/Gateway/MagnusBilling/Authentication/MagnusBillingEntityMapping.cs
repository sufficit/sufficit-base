using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.MagnusBilling
{
    /// <summary>
    /// Entity mapping between MagnusBilling IDs and Sufficit entities
    /// Maintains compatibility while using Sufficit data internally
    /// </summary>
    public class MagnusBillingEntityMapping
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("magnusbilling_entity_type")]
        public string MagnusBillingEntityType { get; set; } = string.Empty;

        [JsonPropertyName("magnusbilling_entity_id")]
        public string MagnusBillingEntityId { get; set; } = string.Empty;

        [JsonPropertyName("sufficit_entity_id")]
        public string SufficitEntityId { get; set; } = string.Empty;

        [JsonPropertyName("context_id")]
        public Guid ContextId { get; set; }

        [JsonPropertyName("api_key_id")]
        public Guid? ApiKeyId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("metadata")]
        public string? Metadata { get; set; }
    }
}