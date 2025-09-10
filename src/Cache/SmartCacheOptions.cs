using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Cache
{
    /// <summary>
    /// Configuration options for smart cache system
    /// </summary>
    public sealed class SmartCacheOptions
    {
        #region Properties

        /// <summary>
        /// Redis connection string or Unix socket path
        /// </summary>
        [JsonPropertyName("connectionString")]
        [JsonPropertyOrder(0)]
        public string ConnectionString { get; set; } = "localhost:6379";

        /// <summary>
        /// Password for Redis authentication
        /// </summary>
        [JsonPropertyName("password")]
        [JsonPropertyOrder(1)]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Default cache refresh policy
        /// </summary>
        [JsonPropertyName("defaultPolicy")]
        [JsonPropertyOrder(2)]
        public CacheRefreshPolicy DefaultPolicy { get; set; } = new CacheRefreshPolicy();

        /// <summary>
        /// Module-specific cache policies (key: module name, value: policy)
        /// </summary>
        [JsonPropertyName("modulePolicies")]
        [JsonPropertyOrder(3)]
        public Dictionary<string, CacheRefreshPolicy> ModulePolicies { get; set; } = new Dictionary<string, CacheRefreshPolicy>();

        /// <summary>
        /// Maximum concurrent background refresh operations
        /// </summary>
        [JsonPropertyName("maxConcurrentRefresh")]
        [JsonPropertyOrder(4)]
        public int MaxConcurrentRefresh { get; set; } = Environment.ProcessorCount;

        /// <summary>
        /// Prefix for all cache keys
        /// </summary>
        [JsonPropertyName("keyPrefix")]
        [JsonPropertyOrder(5)]
        public string KeyPrefix { get; set; } = "sufficit:";

        /// <summary>
        /// Whether to enable performance metrics collection
        /// </summary>
        [JsonPropertyName("metrics")]
        [JsonPropertyOrder(6)]
        public bool Metrics { get; set; } = true;

        /// <summary>
        /// Whether to log cache operations for debugging
        /// </summary>
        [JsonPropertyName("logging")]
        [JsonPropertyOrder(7)]
        public bool Logging { get; set; } = false;

        /// <summary>
        /// Enable background refresh operations globally
        /// </summary>
        [JsonPropertyName("backgroundRefresh")]
        [JsonPropertyOrder(8)]
        public bool BackgroundRefresh { get; set; } = true;

        #endregion

        #region Methods

        /// <summary>
        /// Gets the cache policy for a specific module
        /// </summary>
        /// <param name="moduleName">Name of the module</param>
        /// <returns>Cache policy for the module or default policy</returns>
        public CacheRefreshPolicy GetPolicyForModule(string moduleName)
        {
            return ModulePolicies.TryGetValue(moduleName, out var policy) ? policy : DefaultPolicy;
        }

        /// <summary>
        /// Sets a cache policy for a specific module
        /// </summary>
        /// <param name="moduleName">Name of the module</param>
        /// <param name="policy">Cache policy to use</param>
        public void SetPolicyForModule(string moduleName, CacheRefreshPolicy policy)
        {
            ModulePolicies[moduleName] = policy;
        }

        #endregion
    }
}
