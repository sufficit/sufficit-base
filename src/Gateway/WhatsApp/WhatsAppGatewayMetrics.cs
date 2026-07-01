namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// WhatsApp gateway FastAGI routing metrics constants.
    /// </summary>
    public static class WhatsAppGatewayMetrics
    {
        public const string Started = "whatsapp_gateway_started";
        public const string Resolved = "whatsapp_gateway_resolved";
        public const string Rejected = "whatsapp_gateway_rejected";
        public const string Failed = "whatsapp_gateway_failed";
        public const string Completed = "whatsapp_gateway_completed";
        public const string RouteLoadTime = "whatsapp_gateway_route_load_time";
        public const string TotalExecutionTime = "whatsapp_gateway_total_execution_time";
        public const string CacheHit = "whatsapp_gateway_cache_hit";
        public const string CacheMiss = "whatsapp_gateway_cache_miss";
    }
}
