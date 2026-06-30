namespace Sufficit.Gateway.QuePasa
{
    /// <summary>
    /// QuePasa gateway FastAGI routing metrics constants.
    /// </summary>
    public static class QuePasaGatewayMetrics
    {
        public const string Started = "quepasa_gateway_started";
        public const string Resolved = "quepasa_gateway_resolved";
        public const string Rejected = "quepasa_gateway_rejected";
        public const string Failed = "quepasa_gateway_failed";
        public const string Completed = "quepasa_gateway_completed";
        public const string RouteLoadTime = "quepasa_gateway_route_load_time";
        public const string TotalExecutionTime = "quepasa_gateway_total_execution_time";
        public const string CacheHit = "quepasa_gateway_cache_hit";
        public const string CacheMiss = "quepasa_gateway_cache_miss";
        public const string CacheFallback = "quepasa_gateway_cache_fallback";
    }
}