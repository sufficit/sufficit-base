using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Evento da timeline de uma rota WhatsApp (conexões, desconexões, mudanças de política).
    /// </summary>
    public class WhatsAppDiagnosticTimelineEvent
    {
        /// <summary>Tipo do evento (ex: "connected", "disconnected", "policy_changed", "session_started").</summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>Timestamp do evento (UTC). Null quando desconhecido.</summary>
        [JsonPropertyName("timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>Descrição curta do evento em PT-BR (ex: "Sessão conectada", "Sessão parada pelo usuário").</summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>Opcional: metadados adicionais (JSON livre) para filtros e detalhes.</summary>
        [JsonPropertyName("metadata")]
        public string? Metadata { get; set; }
    }
}