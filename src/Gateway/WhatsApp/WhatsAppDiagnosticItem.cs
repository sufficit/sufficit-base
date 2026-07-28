using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Um item individual do checklist de diagnóstico — atômico, autocontido, tanto para Quepasa
    /// quanto para WhatsApp Oficial. O backend popula todos os campos; o frontend apenas renderiza.
    /// </summary>
    public class WhatsAppDiagnosticItem
    {
        /// <summary>
        /// Identificador estável do item (ex: "quepasa_gateway_reachable", "meta_token_valid").
        /// Usado para testes e para o agente de IA saber que item é qual.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>Título curto do item (ex: "Servidor Quepasa alcançável", "Token Meta válido").</summary>
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>Descrição mais longa do item (ex: "O gateway respondeu dentro de 200ms").</summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>Severidade do item — Ok/Warning/Error/Unknown.</summary>
        [JsonPropertyName("severity")]
        public WhatsAppDiagnosticSeverity Severity { get; set; } = WhatsAppDiagnosticSeverity.Unknown;

        /// <summary>True quando o item é crítico para o funcionamento da rota.</summary>
        [JsonPropertyName("critical")]
        public bool Critical { get; set; }

        /// <summary>Links de documentação/suporte associados ao item (vazio quando não há).</summary>
        [JsonPropertyName("help_links")]
        public List<WhatsAppDiagnosticHelpLink> HelpLinks { get; set; } = new();

        /// <summary>Comentários adicionais (contexto, notas temporárias).</summary>
        [JsonPropertyName("comments")]
        public List<WhatsAppDiagnosticComment> Comments { get; set; } = new();

        /// <summary>Metadados brutos do provedor (ex: código de erro Quepasa, JSON de resposta Meta).</summary>
        [JsonPropertyName("raw_metadata")]
        public string? RawMetadata { get; set; }
    }
}