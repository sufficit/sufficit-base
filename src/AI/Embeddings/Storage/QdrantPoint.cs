using System;
using System.Collections.Generic;

namespace Sufficit.AI.Embeddings.Storage
{
    /// <summary>
    /// Represents a point in Qdrant vector database
    /// </summary>
    public class QdrantPoint
    {
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