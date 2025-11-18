using System;

namespace Sufficit.AI.Embeddings
{
    /// <summary>
    /// Response after successfully storing an embedding
    /// </summary>
    public class StoreEmbeddingResponse
    {

        #region Properties

        /// <summary>
        /// ID of the stored embedding
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Timestamp when the embedding was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Expiration date of the embedding
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Storage location (e.g., GCS object path)
        /// </summary>
        public string? StorageLocation { get; set; }

        #endregion

    }
}
