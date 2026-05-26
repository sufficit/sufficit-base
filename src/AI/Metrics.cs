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
    }

    /// <summary>
    /// Shared metric tags for the Sufficit AI memory domain.
    /// </summary>
    public static class AIMetricTags
    {
        public const string ContextId = "contextid";
        public const string ObservationType = "observation_type";
        public const string Source = "source";
        public const string Resolution = "resolution";
        public const string HybridEnabled = "hybrid_enabled";
        public const string Success = "success";
        public const string SearchMethod = "search_method";
    }

    /// <summary>
    /// Shared metric subtype values for the Sufficit AI memory domain.
    /// </summary>
    public static class AIMetricSubtypes
    {
        public const string Qdrant = "qdrant";
        public const string Db = "db";
        public const string HybridMixed = "hybrid_mixed";
        public const string Fulltext = "fulltext";
        public const string Like = "like";
    }
}
