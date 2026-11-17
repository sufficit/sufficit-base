using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>Credential-free public identity in the customer's telephony inventory.</summary>
    public sealed class OutboundCallerIdentity
    {
        public Guid DidId { get; set; }
        public string Number { get; set; } = string.Empty;
        public Guid ProviderId { get; set; }
        public DateTime? ExpirationUtc { get; set; }
    }
}
