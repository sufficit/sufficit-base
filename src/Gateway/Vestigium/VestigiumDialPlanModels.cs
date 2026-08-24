using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.Vestigium
{
    public enum VestigiumDialPlanFormat
    {
        Json = 0,
        Xml = 1,
        Canonical = 2
    }

    public sealed class VestigiumDialPlanNode
    {
        public string Name { get; set; } = string.Empty;

        public IReadOnlyDictionary<string, string>? Attributes { get; set; }

        public IReadOnlyList<VestigiumDialPlanNode>? Children { get; set; }

        public string? Value { get; set; }
    }

    public sealed class VestigiumCanonicalDialPlan
    {
        [JsonPropertyName("schema")]
        public string Schema { get; set; } = "sufficit.vestigium.dial-plan";

        [JsonPropertyName("version")]
        public string Version { get; set; } = "1.0";

        [JsonPropertyName("contextId")]
        public string ContextId { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("rootIds")]
        public IReadOnlyList<string> RootIds { get; set; } = Array.Empty<string>();

        [JsonPropertyName("nodes")]
        public IReadOnlyList<VestigiumCanonicalNode> Nodes { get; set; } = Array.Empty<VestigiumCanonicalNode>();
    }

    public sealed class VestigiumCanonicalNode
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }

        [JsonPropertyName("destinations")]
        public IReadOnlyList<VestigiumCanonicalDestination> Destinations { get; set; } = Array.Empty<VestigiumCanonicalDestination>();

        [JsonPropertyName("properties")]
        public IReadOnlyDictionary<string, string?> Properties { get; set; } = new Dictionary<string, string?>();

        [JsonPropertyName("extra")]
        public IReadOnlyDictionary<string, string?> Extra { get; set; } = new Dictionary<string, string?>();
    }

    public sealed class VestigiumCanonicalDestination
    {
        [JsonPropertyName("targetId")]
        public string TargetId { get; set; } = string.Empty;

        [JsonPropertyName("label")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }
    }
}
