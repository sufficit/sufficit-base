using System;

namespace Sufficit.Identity
{
    public class TokenValidationResponse
    {
        /// <summary>
        /// Indicates if the token is valid
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Error message if token is invalid
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Token information if valid
        /// </summary>
        public TokenInfo? TokenInfo { get; set; }
    }

    public class TokenInfo
    {
        /// <summary>
        /// Token type (e.g., reference_token, access_token)
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Client ID associated with the token
        /// </summary>
        public string? ClientId { get; set; }

        /// <summary>
        /// Subject/User ID
        /// </summary>
        public string? SubjectId { get; set; }

        /// <summary>
        /// Token creation date
        /// </summary>
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// Token expiration date
        /// </summary>
        public DateTime? Expiration { get; set; }

        /// <summary>
        /// Token description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Scopes/permissions associated with the token
        /// </summary>
        public string[]? Scopes { get; set; }

        /// <summary>
        /// Session ID
        /// </summary>
        public string? SessionId { get; set; }

        /// <summary>
        /// Indicates if token has been consumed
        /// </summary>
        public bool IsConsumed { get; set; }

        /// <summary>
        /// Indicates if token is expired
        /// </summary>
        public bool IsExpired { get; set; }
    }
}
