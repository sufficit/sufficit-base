using System;

namespace Sufficit.Reports
{
    public interface IReportObserver
    {
        /// <summary>
        /// Erro caso haja
        /// </summary>
        Exception Exception { get; }

        /// <summary>
        /// Objeto de controle de progresso para geração de relatórios em segundo plano
        /// </summary>
        IReportProgress Progress { get; }
    }
}
