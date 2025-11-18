using System;
using System.Collections.Generic;

namespace Sufficit.AI.Embeddings
{
    /// <summary>
    /// Request to store an embedding with optional expiration time
    /// </summary>
    public class StoreEmbeddingRequest
    {

        #region Properties

        /// <summary>
        /// Unique identifier for the embedding. If not provided, a new GUID will be generated.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Vector representation to be stored
        /// </summary>
        public float[] Vector { get; set; } = Array.Empty<float>();

        /// <summary>
        /// Optional metadata for filtering and context
        /// </summary>
        public Dictionary<string, object>? Metadata { get; set; }

        /// <summary>
        /// Optional expiration time for this embedding. If not specified, the default expiration (90 days) will be used.
        /// The user can specify any duration (e.g., 30 days, 6 months, 1 year).
        /// </summary>
        public TimeSpan? Expiration { get; set; }

        #endregion

    }
}
