using System;
using System.Text.Json.Serialization;

namespace Sufficit.Cache
{
    /// <summary>
    /// Configuration policy for cache refresh behavior
    /// </summary>
    public sealed class CacheRefreshPolicy
    {
        #region Properties

        /// <summary>
        /// Time to live for cached items
        /// </summary>
        [JsonPropertyName("ttl")]
        [JsonPropertyOrder(0)]
        public TimeSpan TimeToLive { get; set; } = TimeSpan.FromMinutes(30);

        /// <summary>
        /// Percentage of TTL when background refresh should trigger (0.0 to 1.0)
        /// Default is 0.3 (30% of TTL remaining)
        /// </summary>
        [JsonPropertyName("refreshThreshold")]
        [JsonPropertyOrder(1)]
        public double RefreshThreshold { get; set; } = 0.3;

        /// <summary>
        /// Priority for background refresh operations
        /// </summary>
        [JsonPropertyName("priority")]
        [JsonPropertyOrder(2)]
        public CachePriority Priority { get; set; } = CachePriority.Normal;

        /// <summary>
        /// Whether to use write-through cache behavior
        /// </summary>
        [JsonPropertyName("writeThrough")]
        [JsonPropertyOrder(3)]
        public bool WriteThrough { get; set; } = true;

        /// <summary>
        /// Whether to enable background refresh
        /// </summary>
        [JsonPropertyName("backgroundRefresh")]
        [JsonPropertyOrder(4)]
        public bool BackgroundRefresh { get; set; } = true;

        #endregion

        #region Methods

        /// <summary>
        /// Gets the time when background refresh should trigger
        /// </summary>
        /// <param name="createdAt">When the cache entry was created</param>
        /// <returns>Timestamp when refresh should occur</returns>
        public DateTime GetRefreshTime(DateTime createdAt)
        {
            var refreshDelay = TimeSpan.FromTicks((long)(TimeToLive.Ticks * RefreshThreshold));
            return createdAt.Add(refreshDelay);
        }

        /// <summary>
        /// Gets the absolute expiration time for the cache entry
        /// </summary>
        /// <param name="createdAt">When the cache entry was created</param>
        /// <returns>Absolute expiration timestamp</returns>
        public DateTime GetExpirationTime(DateTime createdAt)
        {
            return createdAt.Add(TimeToLive);
        }

        #endregion
    }
}
