using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Reports
{
    /// <summary>
    ///     Interface for report progress info properties
    /// </summary>
    public interface IReportProgress
    {
        /// <summary>
        ///     Process progress percentage (always positive)
        /// </summary>
        uint Percentage { get; }

        /// <summary>
        ///     Process info text status message
        /// </summary>
        string? Status { get; }

        /// <summary>
        ///     Named process step, if exists
        /// </summary>
        ReportStepEnum Step { get; }
    }
}
