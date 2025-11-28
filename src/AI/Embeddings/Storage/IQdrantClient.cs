using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.AI.Embeddings.Storage
{
    /// <summary>
    /// Interface for Qdrant HTTP client operations to enable unit testing
    /// </summary>
    public interface IQdrantClient
    {
        Task<bool> CollectionExistsAsync(CancellationToken cancellationToken = default);
        Task CreateCollectionAsync(int vectorSize, string distance = "Cosine", CancellationToken cancellationToken = default);
        Task<string> UpsertPointAsync(string id, float[] vector, Dictionary<string, object> payload, CancellationToken cancellationToken = default);
        Task<QdrantPoint?> GetPointAsync(string id, CancellationToken cancellationToken = default);
        Task<List<QdrantSearchResult>> SearchAsync(float[] vector, int limit = 10, Dictionary<string, object>? filter = null, CancellationToken cancellationToken = default);
        Task<bool> DeletePointAsync(string id, CancellationToken cancellationToken = default);
        Task<List<QdrantPoint>> ScrollAsync(Dictionary<string, object>? filter = null, int limit = 100, CancellationToken cancellationToken = default);
    }
}