using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    /// <summary>Curated fiscal service classification available for invoice issuing.</summary>
    public class FiscalServiceView
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>National taxation code (LC 116 item), e.g. 01.07.01.</summary>
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;

        /// <summary>Exact service name registered at the provider.</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
