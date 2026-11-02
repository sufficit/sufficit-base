using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>Selection saved through <c>PUT /Telephony/ChromeExtension/Lines</c>.</summary>
    public sealed class ChromeExtensionLinesRequest
    {
        [JsonPropertyName("endpointIds")]
        public List<Guid> EndPointIds { get; set; } = new List<Guid>();

        [JsonPropertyName("primaryId")]
        public Guid? PrimaryId { get; set; }
    }

    /// <summary>Lines returned by <c>GET /Telephony/ChromeExtension/Lines</c>.</summary>
    public sealed class ChromeExtensionLinesResponse
    {
        [JsonPropertyName("userId")]
        public Guid UserId { get; set; }

        [JsonPropertyName("maxLines")]
        public int MaxLines { get; set; }

        [JsonPropertyName("lines")]
        public List<ChromeExtensionLine> Lines { get; set; } = new List<ChromeExtensionLine>();
    }

    public sealed class ChromeExtensionLine
    {
        [JsonPropertyName("endpointId")] public Guid EndPointId { get; set; }
        [JsonPropertyName("extension")] public string Extension { get; set; } = "";
        [JsonPropertyName("password")] public string Password { get; set; } = "";
        [JsonPropertyName("displayName")] public string DisplayName { get; set; } = "";
        [JsonPropertyName("title")] public string Title { get; set; } = "";
        [JsonPropertyName("aor")] public string Aor { get; set; } = "";
        [JsonPropertyName("server")] public string[] Server { get; set; } = Array.Empty<string>();
        [JsonPropertyName("contextId")] public Guid ContextId { get; set; }
        [JsonPropertyName("clientName")] public string? ClientName { get; set; }
        [JsonPropertyName("primary")] public bool Primary { get; set; }
    }

    public sealed class ChromeExtensionAvailableLine
    {
        [JsonPropertyName("endpointId")] public Guid EndPointId { get; set; }
        [JsonPropertyName("title")] public string Title { get; set; } = "";
        [JsonPropertyName("contextId")] public Guid ContextId { get; set; }
        [JsonPropertyName("clientName")] public string? ClientName { get; set; }
        [JsonPropertyName("selected")] public bool Selected { get; set; }
    }
}
