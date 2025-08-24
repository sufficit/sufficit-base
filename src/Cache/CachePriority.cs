namespace Sufficit.Cache
{
    /// <summary>
    /// Priority levels for cache operations
    /// </summary>
    public enum CachePriority
    {
        /// <summary>
        /// Low priority - background refresh can be delayed
        /// </summary>
        Low = 0,

        /// <summary>
        /// Normal priority - standard refresh timing
        /// </summary>
        Normal = 1,

        /// <summary>
        /// High priority - refresh as soon as possible
        /// </summary>
        High = 2,

        /// <summary>
        /// Critical priority - immediate refresh required
        /// </summary>
        Critical = 3
    }
}
