using System;

namespace Sufficit.AI.Embeddings
{
    /// <summary>
    /// Request to update the expiration time of an existing embedding
    /// </summary>
    public class UpdateExpirationRequest
    {

        #region Properties

        /// <summary>
        /// ID of the embedding to update
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// New expiration time to set. This will be added to the current date.
        /// For example, TimeSpan.FromDays(365) will set expiration to 1 year from now.
        /// </summary>
        public TimeSpan Expiration { get; set; }

        #endregion

    }
}
