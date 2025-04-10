using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Reports
{
    public interface IReportGenericAbstract : IReport
    {
        new Guid Id { get; set; }

        ReportParameters? Parameters { get; set; }

        /// <summary>
        ///     Start and don't follow the background process <br />
        ///     Use the same async context that method who called
        /// </summary>
        void Start (CancellationToken cancellationToken);

        /// <summary>
        ///     Get and follow the background process
        /// </summary>
        Task BackgroundProcess (CancellationToken cancellationToken);
    }
}
