using System.Text.Json.Serialization;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Nível de severidade de um item de diagnóstico — usado tanto para Quepasa quanto
    /// para WhatsApp Oficial (Meta). Apenas informativo; o backend não altera nada com base nisso.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<WhatsAppDiagnosticSeverity>))]
    public enum WhatsAppDiagnosticSeverity
    {
        /// <summary>Nenhum problema detectado neste item.</summary>
        [JsonPropertyName("ok")]
        Ok,

        /// <summary>Atenção: não impede funcionamento, mas pode explicar um problema ou ser um ponto de melhoria.</summary>
        [JsonPropertyName("warning")]
        Warning,

        /// <summary>Erro: este item precisa de ação para que a rota funcione corretamente.</summary>
        [JsonPropertyName("error")]
        Error,

        /// <summary>Não foi possível verificar este item (ex: sessão offline, erro ao consultar provedor).</summary>
        [JsonPropertyName("unknown")]
        Unknown
    }
}