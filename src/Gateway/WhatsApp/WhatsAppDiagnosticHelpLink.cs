using System.Text.Json.Serialization;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Link de ajuda associado a um item de diagnóstico — documenta o problema e como resolver.
    /// </summary>
    public class WhatsAppDiagnosticHelpLink
    {
        /// <summary>Título curto do link (ex: "Como desvincular um aparelho antigo").</summary>
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>URL absoluta do artigo ou documentação.</summary>
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        /// <summary>Opcional: idioma do link (ISO 639-1, ex: "pt-BR").</summary>
        [JsonPropertyName("language")]
        public string? Language { get; set; }
    }
}