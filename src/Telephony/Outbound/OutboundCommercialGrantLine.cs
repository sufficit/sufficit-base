using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>One versioned commercial contract line, independent of operational route order.</summary>
    public class OutboundCommercialGrantLine
    {
        public Guid Id { get; set; }
        public Guid ContextId { get; set; }
        public Guid ServiceId { get; set; }
        public int Channels { get; set; }
        public DateTime StartUtc { get; set; }
        public DateTime ExpirationUtc { get; set; }
        public OutboundAdministrativeState AdministrativeState { get; set; } = OutboundAdministrativeState.Enabled;
        public string SourceSystem { get; set; } = string.Empty;
        public string ExternalContractLineId { get; set; } = string.Empty;
        public long SourceVersion { get; set; }
        public string? LastPayloadHash { get; set; }
        public long Revision { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }

        public bool IsEligibleAt(DateTime utcNow)
            => Channels > 0
                && AdministrativeState == OutboundAdministrativeState.Enabled
                && OutboundValidity.Contains(StartUtc, ExpirationUtc, utcNow);
    }
}
