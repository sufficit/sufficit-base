using System;

namespace Sufficit.Identity
{
    public class TokenExpirationUpdateRequest
    {
        public string Key { get; set; } = default!;

        /// <summary>
        /// Gets or sets the expiration date associated with the object.
        /// </summary>
        public DateTime? Expiration { get; set; }
    }
}
