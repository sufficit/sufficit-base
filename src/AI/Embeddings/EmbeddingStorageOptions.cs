using System;

namespace Sufficit.AI.Embeddings
{
    /// <summary>
    /// Configuration options for embedding storage in Google Cloud Storage
    /// </summary>
    public class EmbeddingStorageOptions
    {

        #region Properties

        /// <summary>
        /// Google Cloud Storage bucket name where embeddings will be stored
        /// </summary>
        public string BucketName { get; set; } = "suff-embeddings";

        /// <summary>
        /// Default expiration time for embeddings if not specified by the user
        /// </summary>
        public TimeSpan DefaultExpiration { get; set; } = TimeSpan.FromDays(90);

        /// <summary>
        /// Google Cloud Project ID
        /// </summary>
        public string ProjectId { get; set; } = string.Empty;

        /// <summary>
        /// Path to the Google Cloud credentials JSON file
        /// </summary>
        public string? CredentialsPath { get; set; }

        #endregion

    }
}
