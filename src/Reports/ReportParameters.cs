using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Reports
{
    public abstract class ReportParameters : IReportParameters
    {
        /// <summary>
        /// Contexto de representação do relatório, cliente ou usuário
        /// </summary>
        public Guid ContextId { get; protected set; }

        /// <summary>
        /// Contexto de representação do relatório, cliente ou usuário
        /// </summary>
        public Guid IDContext { get => ContextId; protected set => ContextId = value; }

        /// <summary>
        /// Momento de início do relatório
        /// </summary>
        public DateTime DTStart { get; protected set; }

        /// <summary>
        /// Momento do término do relatório
        /// </summary>
        public DateTime DTEnd { get; protected set; }

        /// <summary>
        /// Tempo de diferença entre UTC e o horário regional do usuário solicitante
        /// </summary>
        public TimeSpan? OffSet { get; protected set; }

        /// <summary>
        /// (UTC) Momento em que foi solicitado o relatório \n
        /// Usado somente para controle
        /// </summary>
        public DateTime DTCreation { get; protected set; }
    }
}
