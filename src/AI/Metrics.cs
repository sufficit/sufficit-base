
namespace Sufficit.AI
{
    /// <summary>
    /// Shared metric names for the Sufficit AI domain.
    /// </summary>
    public static class AIMetrics
    {
        public const string MemorySearchTotal = "ai_memory_search_total";
        public const string MemorySearchHybridAttemptTotal = "ai_memory_search_hybrid_attempt_total";
        public const string MemorySearchQdrantHitTotal = "ai_memory_search_qdrant_hit_total";
        public const string MemorySearchDbOnlyTotal = "ai_memory_search_db_only_total";
        public const string MemorySearchResultCount = "ai_memory_search_result_count";
        public const string MemorySearchQdrantHitCount = "ai_memory_search_qdrant_hit_count";
        public const string MemorySearchDurationMs = "ai_memory_search_duration_ms";
        public const string MemoryQdrantSearchDurationMs = "ai_memory_qdrant_search_duration_ms";
        public const string MemorySaveTotal = "ai_memory_save_total";
        public const string MemoryIndexQdrantSuccessTotal = "ai_memory_index_qdrant_success_total";
        public const string MemoryIndexQdrantFailureTotal = "ai_memory_index_qdrant_failure_total";
        public const string MemorySearchFullTextHitTotal = "ai_memory_search_fulltext_hit_total";
        public const string MemorySearchFullTextHitCount = "ai_memory_search_fulltext_hit_count";
        public const string MemoryObservationHitTotal = "ai_memory_observation_hit_total";
        public const string MemoryObservationViewTotal = "ai_memory_observation_view_total";

        public const string RequestTotal = "ai_request_total";
        public const string RequestDurationMs = "ai_request_duration_ms";
        public const string RequestTokensIn = "ai_request_tokens_in";
        public const string RequestTokensOut = "ai_request_tokens_out";
        public const string RequestFailureTotal = "ai_request_failure_total";

        public const string CompressionTotal = "ai_compression_total";
        public const string CompressionMessagesRemoved = "ai_compression_messages_removed";
        public const string CompressionToolCallsPruned = "ai_compression_tool_calls_pruned";
        public const string CompressionToolResultsTruncated = "ai_compression_tool_results_truncated";
        public const string CompressionCharsSaved = "ai_compression_chars_saved";

        public const string DispatchTotal = "ai_dispatch_total";
        public const string DispatchFallbackTotal = "ai_dispatch_fallback_total";

        public const string ProviderHealth = "ai_provider_health";
        public const string ProviderUsagePct = "ai_provider_usage_pct";

        public const string CreditConsumed = "ai_credit_consumed";
        public const string CreditBalance = "ai_credit_balance";
    }

    /// <summary>
    /// Shared metric tags for the Sufficit AI domain.
    /// </summary>
    public static class AIMetricTags
    {
        public const string ExecutionId = "execution_id";
        public const string ContextId = "contextid";
        public const string FailureReason = "failure_reason";
        public const string ObservationType = "observation_type";
        public const string Source = "source";
        public const string Resolution = "resolution";
        public const string HybridEnabled = "hybrid_enabled";
        public const string Success = "success";
        public const string Enabled = "enabled";
        public const string SearchMethod = "search_method";
        public const string Operation = "operation";
        public const string TotalAttempts = "total_attempts";
        public const string EffectiveAttemptIndex = "effective_attempt_index";
        public const string PresetId = "preset_id";
        public const string HealthState = "health_state";
        public const string HealthSource = "health_source";
        public const string HealthMessage = "health_message";
        public const string RequestedModel = "requested_model";
        public const string ProviderKey = "provider_key";
        public const string ProviderTitle = "provider_title";
        public const string ProviderType = "provider_type";
        public const string BackendModel = "backend_model";
        public const string ConsumerContextId = "consumer_context_id";
        public const string OwnerContextId = "owner_context_id";
        public const string FinishReason = "finish_reason";
        public const string Streamed = "streamed";
        public const string Server = "server";
        public const string CompressionStrategy = "compression_strategy";
        public const string CompressionEnabled = "compression_enabled";
        public const string UserAgentFamily = "user_agent_family";
        public const string UserAgentChannel = "user_agent_channel";
        public const string UserAgentVersionMajor = "user_agent_version_major";
        public const string CreditRole = "credit_role";
    }

    /// <summary>
    /// Shared metric subtype values for the Sufficit AI domain.
    /// </summary>
    public static class AIMetricSubtypes
    {
        public const string Qdrant = "qdrant";
        public const string Db = "db";
        public const string HybridMixed = "hybrid_mixed";
        public const string Fulltext = "fulltext";
        public const string Like = "like";
        public const string Messages = "messages";
        public const string ToolResults = "tool_results";
        public const string Deduplicate = "deduplicate";
        public const string HistoricalToolCalls = "historical_tool_calls";
        public const string Combined = "combined";
        public const string Consumer = "consumer";
        public const string Owner = "owner";
    }
}
