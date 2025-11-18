namespace Sufficit.AI.Embeddings
{
    /// <summary>
    /// Result of a similarity search containing the embedding and its similarity score
    /// </summary>
    public class EmbeddingSearchResult
    {

        #region Properties

        /// <summary>
        /// The embedding that matched the search query
        /// </summary>
        public Embedding Embedding { get; set; } = new Embedding();

        /// <summary>
        /// Similarity score between the query vector and this embedding (0.0 to 1.0, higher is more similar)
        /// </summary>
        public float Similarity { get; set; }

        #endregion

    }
}
