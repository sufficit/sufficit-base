using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sufficit.Reports
{
    public interface IReportWebTricks<T> : IReportWebTricks
    {
        IEnumerable<T> Items { get; }
    }

    /// <summary>
    /// Interface para juntar as propriedades principais de um relatório gerado na web
    /// </summary>
    public interface IReportWebTricks : IReportParameters, IReportObserver, IReportProgress, IIndex
    {
        /// <summary>
        /// Legendas a serem exibidas
        /// </summary>
        IEnumerable<ReportWebCaption> Captions { get; }

        /// <summary>
        /// Qualquer informação útil ao administrador
        /// </summary>
        IEnumerable<ReportWebCaption> Debug { get; }

        string GetFileNamePrefix();

        string? Notify { get; }

        void Start(CancellationToken cancellationToken = default);
    }
}
