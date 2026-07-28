using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Relatório completo de diagnóstico de uma rota WhatsApp — genérico, unificado para Quepasa
    /// e WhatsApp Oficial (Meta). O endpoint único devolve isso; o Blazor e o agente de IA o consomem.
    /// </summary>
    public class WhatsAppDiagnosticReport
    {
        /// <summary>SessionId da rota diagnosticada (same como WhatsAppGatewayRoute.SessionId).</summary>
        [JsonPropertyName("session_id")]
        public string SessionId { get; set; } = string.Empty;

        /// <summary>ContextId associado (para checagem de autorização/pos).</summary>
        [JsonPropertyName("context_id")]
        public Guid ContextId { get; set; }

        /// <summary>Provedor: "quepasa" ou "official" (Meta/Cloud API).</summary>
        [JsonPropertyName("provider")]
        public string Provider { get; set; } = string.Empty;

        /// <summary>Número de telefone E.164 (com "+", ex: "+5511999999999").</summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        /// <summary>Display name do número (para Quepasa = Wid formatado, para Meta = display_phone_number).</summary>
        [JsonPropertyName("display_name")]
        public string? DisplayName { get; set; }

        /// <summary>Nome verificado (para Meta = verified_name, para Quepasa = desconhecido).</summary>
        [JsonPropertyName("verified_name")]
        public string? VerifiedName { get; set; }

        /// <summary>Estado de conexão atual (Quepasa: state string, Meta: status se disponível, null se desconhecido).</summary>
        [JsonPropertyName("connection_state")]
        public string? ConnectionState { get; set; }

        /// <summary>True quando o número está marcado como Enabled na rota (roteamento habilitado).</summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>Destino configurado (DestinationAsterisk), ou null quando não definido.</summary>
        [JsonPropertyName("destination")]
        public string? Destination { get; set; }

        /// <summary>Timestamp UTC do diagnóstico (quando o backend gerou este relatório).</summary>
        [JsonPropertyName("diagnosed_at")]
        public DateTime DiagnosedAt { get; set; }

        /// <summary>Checklist de itens de diagnóstico (gerado pelo backend, ordenado por importância).</summary>
        [JsonPropertyName("items")]
        public List<WhatsAppDiagnosticItem> Items { get; set; } = new();

        /// <summary>Timeline de eventos recentes (conexões/desconexões, mudanças de política).</summary>
        [JsonPropertyName("timeline")]
        public List<WhatsAppDiagnosticTimelineEvent> Timeline { get; set; } = new();

        /// <summary>Opcional: resumo curto em PT-BR (ex: "Sessão conectada, mas calls_enabled=false").</summary>
        [JsonPropertyName("summary")]
        public string? Summary { get; set; }
    }
}