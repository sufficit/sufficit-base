using System;
using System.Collections.Generic;

namespace Sufficit.AI.Embeddings.Storage
{
    /// <summary>
    /// Extension methods for QdrantSearchResult
    /// </summary>
    public static class QdrantSearchResultExtensions
    {
        /// <summary>
        /// Gets the point data from search result
        /// </summary>
        public static QdrantPoint ToPoint(this QdrantSearchResult result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            return new QdrantPoint
            {
                Id = result.Id,
                Vector = result.Vector,
                Payload = result.Payload
            };
        }
    }
}