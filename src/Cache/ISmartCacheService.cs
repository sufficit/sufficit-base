using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Cache
{
    /// <summary>
    /// Interface for smart cache service with background refresh capabilities
    /// </summary>
    /// <typeparam name="TKey">Type of cache key</typeparam>
    /// <typeparam name="TValue">Type of cached value</typeparam>
    public interface ISmartCacheService<TKey, TValue>
        where TKey : notnull
        where TValue : class
    {
        /// <summary>
        /// Gets a value from cache or loads from source if not found
        /// </summary>
        /// <param name="key">Cache key</param>
        /// <param name="loader">Function to load data if not in cache</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Cached or loaded value</returns>
        Task<TValue> GetOrLoadAsync(TKey key, Func<TKey, CancellationToken, Task<TValue>> loader, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets a value in cache with write-through behavior
        /// </summary>
        /// <param name="key">Cache key</param>
        /// <param name="value">Value to cache</param>
        /// <param name="policy">Cache policy to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task SetAsync(TKey key, TValue value, CacheRefreshPolicy? policy = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes a value from cache
        /// </summary>
        /// <param name="key">Cache key to remove</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task RemoveAsync(TKey key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes multiple values from cache by pattern
        /// </summary>
        /// <param name="pattern">Key pattern to match</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task RemoveByPatternAsync(string pattern, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets cache statistics for monitoring
        /// </summary>
        Task<CacheStatistics> GetStatisticsAsync(CancellationToken cancellationToken = default);
    }
}
