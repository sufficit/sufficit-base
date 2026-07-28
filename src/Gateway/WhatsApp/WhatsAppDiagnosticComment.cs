using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Comentário adicional explicativo sobre um item de diagnóstico — sem ação direta,
    /// usado para dar contexto (ex: "essa posição é comum ao desconectar/reconectar").
    /// </summary>
    public class WhatsAppDiagnosticComment
    {
        /// <summary>Texto do comentário em PT-BR (ou idioma do contexto).</summary>
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;

        /// <summary>Momento em que o comentário foi adicionado (normalmente = timestamp do diagnóstico).</summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>Opcional: origem do comentário (ex: "quepasa", "meta", "sufficit").</summary>
        [JsonPropertyName("source")]
        public string? Source { get; set; }
    }
}