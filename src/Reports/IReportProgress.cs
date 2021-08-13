using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Reports
{
    /// <summary>
    /// Interface para informar o progresso de geração de um relatório
    /// </summary>
    public interface IReportProgress
    {
        /// <summary>
        /// Progresso de geração em porcentagem (sempre positivo)
        /// </summary>
        uint Percentage { get; }

        /// <summary>
        /// Descrição sobre o estado atual do processo
        /// </summary>
        string Status { get; }

        /// <summary>
        /// Etapa atual do processo
        /// </summary>
        ReportStepEnum Step { get; }
    }
}
