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

    /// <summary>Who to look for. The number goes in the body to stay out of URL logs.</summary>
    public sealed class ChromeExtensionCallerRequest
    {
        [JsonPropertyName("number")] public string? Number { get; set; }
        [JsonPropertyName("lineId")] public Guid? LineId { get; set; }
    }

    /// <summary>The contact on a softphone call; the photo is served by <c>contact/avatar?contextid=</c>.</summary>
    public sealed class ChromeExtensionCaller
    {
        [JsonPropertyName("contactId")] public Guid ContactId { get; set; }
        [JsonPropertyName("title")] public string Title { get; set; } = "";
        [JsonPropertyName("hasAvatar")] public bool HasAvatar { get; set; }
    }

    /// <summary>An extension the user may choose. Never carries credentials: the management page reads it.</summary>
    public sealed class ChromeExtensionAvailableLine
    {
        [JsonPropertyName("endpointId")] public Guid EndPointId { get; set; }
        [JsonPropertyName("title")] public string Title { get; set; } = "";
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("contextId")] public Guid ContextId { get; set; }
        [JsonPropertyName("clientName")] public string? ClientName { get; set; }
        [JsonPropertyName("selected")] public bool Selected { get; set; }
        [JsonPropertyName("primary")] public bool Primary { get; set; }
    }
}
