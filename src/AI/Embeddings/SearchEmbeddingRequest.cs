using System.Collections.Generic;

namespace Sufficit.AI.Embeddings
{
    /// <summary>
    /// Request to search for similar embeddings using vector similarity
    /// </summary>
    public class SearchEmbeddingRequest
    {

        #region Properties

        /// <summary>
        /// Query vector to find similar embeddings
        /// </summary>
        public float[] QueryVector { get; set; } = System.Array.Empty<float>();

        /// <summary>
        /// Number of top similar results to return (default: 10)
        /// </summary>
        public int TopK { get; set; } = 10;

        /// <summary>
        /// Optional metadata filter to narrow down search results
        /// </summary>
        public Dictionary<string, object>? Filter { get; set; }

        #endregion

    }
}
