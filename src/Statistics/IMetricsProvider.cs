using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Statistics
{
    /// <summary>
    /// Base interface for metrics providers supporting different storage backends
    /// </summary>
    public interface IMetricsProvider
    {
        /// <summary>
        /// Write a single metric value with optional tags
        /// </summary>
        /// <typeparam name="T">Value type (must be struct)</typeparam>
        /// <param name="measurement">Measurement name</param>
        /// <param name="value">Metric value</param>
        /// <param name="tags">Optional tags for filtering and grouping</param>
        /// <param name="timestamp">Metric timestamp (defaults to current time)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task WriteAsync<T>(
            string measurement, 
            T value, 
            Dictionary<string, string>? tags = null, 
            DateTime? timestamp = null, 
            CancellationToken cancellationToken = default) where T : struct;

        /// <summary>
        /// Write multiple individual metrics in bulk operation (any metrics)
        /// Bulk: Any collection of individual metrics for mass processing
        /// </summary>
        /// <param name="metrics">Collection of individual metrics to write in bulk</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task WriteBulkAsync(IEnumerable<Metric> metrics, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query metrics using provider-specific query language
        /// </summary>
        /// <param name="query">Query string (format depends on provider)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Query results</returns>
        Task<IEnumerable<Metric>> QueryAsync(string query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Search metrics using structured parameters
        /// </summary>
        /// <param name="parameters">Search parameters</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Query results</returns>
        Task<IEnumerable<Metric>> SearchAsync(MetricsSearchParameters parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Check if provider is healthy and available
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if provider is healthy</returns>
        Task<bool> IsHealthyAsync(CancellationToken cancellationToken = default);
    }
}
