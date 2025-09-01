using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Statistics
{
    /// <summary>
    /// Base interface for metrics providers supporting different storage backends
    /// </summary>
    public interface IMetricController
    {
        /// <summary>
        /// Write metric using default pooling system
        /// </summary>
        /// <param name="metric">The metric to write</param>
        void Write(Metric metric);
    }
}
