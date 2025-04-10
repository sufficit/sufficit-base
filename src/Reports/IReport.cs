using System;

namespace Sufficit.Reports
{
    /// <summary>
    ///     Interface for all reports, used for search and cache
    /// </summary>
    public interface IReport : IIndex
    {
        Guid ModelId { get; }

        ReportProgress Progress { get; }
    }
}
