using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Reports
{
    public interface IReportParameters
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
    }
}
