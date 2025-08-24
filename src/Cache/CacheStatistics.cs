using System;
using System.Text.Json.Serialization;

namespace Sufficit.Cache
{
    /// <summary>
    /// Statistics about cache performance and usage
    /// </summary>
    public sealed class CacheStatistics
    {
        #region Properties

        /// <summary>
        /// Total number of cache hits
        /// </summary>
        [JsonPropertyName("hits")]
        [JsonPropertyOrder(0)]
        public long Hits { get; set; }

        /// <summary>
        /// Total number of cache misses
        /// </summary>
        [JsonPropertyName("misses")]
        [JsonPropertyOrder(1)]
        public long Misses { get; set; }

        /// <summary>
        /// Total number of items currently in cache
        /// </summary>
        [JsonPropertyName("itemCount")]
        [JsonPropertyOrder(2)]
        public long ItemCount { get; set; }

        /// <summary>
        /// Total number of background refresh operations performed
        /// </summary>
        [JsonPropertyName("backgroundRefreshes")]
        [JsonPropertyOrder(3)]
        public long BackgroundRefreshes { get; set; }

        /// <summary>
        /// Total number of write-through operations
        /// </summary>
        [JsonPropertyName("writeThroughs")]
        [JsonPropertyOrder(4)]
        public long WriteThroughs { get; set; }

        /// <summary>
        /// Average response time in microseconds
        /// </summary>
        [JsonPropertyName("averageResponseTimeMicroseconds")]
        [JsonPropertyOrder(5)]
        public double AverageResponseTimeMicroseconds { get; set; }

        /// <summary>
        /// When these statistics were last updated
        /// </summary>
        [JsonPropertyName("lastUpdated")]
        [JsonPropertyOrder(6)]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        #endregion

        #region Calculated Properties

        /// <summary>
        /// Cache hit ratio (0.0 to 1.0)
        /// </summary>
        [JsonPropertyName("hitRatio")]
        [JsonPropertyOrder(7)]
        public double HitRatio 
        { 
            get 
            {
                var total = Hits + Misses;
                return total == 0 ? 0.0 : (double)Hits / total;
            }
        }

        /// <summary>
        /// Cache hit ratio as percentage
        /// </summary>
        [JsonPropertyName("hitRatioPercentage")]
        [JsonPropertyOrder(8)]
        public double HitRatioPercentage 
        { 
            get => HitRatio * 100.0; 
        }

        /// <summary>
        /// Total cache operations (hits + misses)
        /// </summary>
        [JsonPropertyName("totalOperations")]
        [JsonPropertyOrder(9)]
        public long TotalOperations 
        { 
            get => Hits + Misses; 
        }

        #endregion

        #region Methods

        /// <summary>
        /// Resets all statistics counters
        /// </summary>
        public void Reset()
        {
            Hits = 0;
            Misses = 0;
            ItemCount = 0;
            BackgroundRefreshes = 0;
            WriteThroughs = 0;
            AverageResponseTimeMicroseconds = 0;
            LastUpdated = DateTime.UtcNow;
        }

        #endregion
    }
}
