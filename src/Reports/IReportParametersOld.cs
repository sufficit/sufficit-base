using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Reports
{
    public interface IReportParametersOld
    {
        /// <summary>
        /// Contexto de representação do relatório, cliente ou usuário
        /// </summary>
        Guid IDContext { get; }

        /// <summary>
        /// Momento de início do relatório
        /// </summary>
        DateTime DTStart { get; }

        /// <summary>
        /// Momento do término do relatório
        /// </summary>
        DateTime DTEnd { get; }

        /// <summary>
        /// Tempo de diferença entre UTC e o horário regional do usuário solicitante
        /// </summary>
        TimeSpan? OffSet { get; }
    }
}
