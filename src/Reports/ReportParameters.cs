using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Reports
{
    public class ReportParameters : IReportParameters
    {
        /// <summary>
        /// Contexto de representação do relatório, cliente ou usuário
        /// </summary>
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Contexto de representação do relatório, cliente ou usuário
        /// </summary>
        [JsonIgnore]
        public Guid IDContext { get => ContextId; set => ContextId = value; }

        /// <summary>
        /// Momento de início do relatório
        /// </summary>
        [JsonPropertyName("dtstart")]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime DTStart { get; set; }

        /// <summary>
        /// Momento do término do relatório
        /// </summary>
        [JsonPropertyName("dtend")]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime DTEnd { get; set; }

        /// <summary>
        /// Tempo de diferença entre UTC e o horário regional do usuário solicitante
        /// </summary>
        [JsonPropertyName("offset")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TimeSpan? OffSet { get; set; }

        /// <summary>
        /// (UTC) Momento em que foi solicitado o relatório \n
        /// Usado somente para controle
        /// </summary>
        [JsonPropertyName("timestamp")]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime DTCreation { get; set; }
    }
}
