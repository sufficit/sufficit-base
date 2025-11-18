using System;
using System.Collections.Generic;

namespace Sufficit.AI.Embeddings
{
    /// <summary>
    /// Represents a vector embedding with metadata and expiration information
    /// </summary>
    public class Embedding
    {

        #region Properties

        /// <summary>
        /// Unique identifier for the embedding
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Vector representation of the embedding (float array for compatibility)
        /// </summary>
        public float[] Vector { get; set; } = Array.Empty<float>();

        /// <summary>
        /// Additional metadata associated with the embedding for filtering and context
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Timestamp when the embedding was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Optional expiration date for the embedding. When set, the storage provider should delete the embedding after this date.
        /// </summary>
        public DateTime? ExpiresAt { get; set; }

        #endregion

    }
}
