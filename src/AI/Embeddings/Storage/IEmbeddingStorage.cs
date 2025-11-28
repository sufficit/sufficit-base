using Sufficit.AI.Embeddings;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.AI.Embeddings.Storage
{
    /// <summary>
    /// Interface for embedding storage operations in vector databases
    /// Implements ICleanUp for on-demand cleanup operations
    /// </summary>
    public interface IEmbeddingStorage : ICleanUp
    {

        #region Methods

        /// <summary>
        /// Store an embedding in the vector database with optional expiration
        /// </summary>
        Task<StoreEmbeddingResponse> StoreAsync(StoreEmbeddingRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve an embedding by its ID
        /// </summary>
        Task<Embedding?> GetAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Search for similar embeddings using vector similarity
        /// </summary>
        Task<IEnumerable<EmbeddingSearchResult>> SearchAsync(SearchEmbeddingRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete an embedding from the vector database
        /// </summary>
        Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the expiration time of an existing embedding
        /// </summary>
        Task<bool> UpdateExpirationAsync(string id, TimeSpan expiration, CancellationToken cancellationToken = default);

        #endregion

    }
}