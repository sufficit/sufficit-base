using System;
using System.ComponentModel.DataAnnotations;

namespace Sufficit.Telephony.DIDs
{
    /// <summary>Explicit operational command; commercial lifecycle events must not submit it.</summary>
    public sealed class DIDExpirationUpdateParameters
    {
        public Guid Id { get; set; }
        public Guid ExpectedContextId { get; set; }
        public DateTime? ExpectedExpiration { get; set; }
        /// <summary>Reviewed UTC expiry. Null explicitly removes the expiry.</summary>
        public DateTime? Expiration { get; set; }
        [Required, StringLength(500, MinimumLength = 3)]
        public string Reason { get; set; } = string.Empty;
    }
}
