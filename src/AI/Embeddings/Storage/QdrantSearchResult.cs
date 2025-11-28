using System;
using System.Collections.Generic;

namespace Sufficit.AI.Embeddings.Storage
{
    /// <summary>
    /// Represents a search result from Qdrant vector database
    /// </summary>
    public class QdrantSearchResult
    {
        /// <summary>
        /// Similarity score of the result
        /// </summary>
        public float Score { get; set; }

        /// <summary>
        /// Unique identifier of the point
        /// </summary>
        public string Id { get; set; } = default!;

        /// <summary>
        /// Vector data
        /// </summary>
        public float[] Vector { get; set; } = default!;

        /// <summary>
        /// Additional payload data
        /// </summary>
        public Dictionary<string, object> Payload { get; set; } = default!;
    }
}