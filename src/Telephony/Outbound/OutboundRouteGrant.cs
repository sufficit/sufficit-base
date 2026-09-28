using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    /// Finite local permission to use a customer-owned route resource. A registered
    /// SIP trunk or WhatsApp number alone does not authorize outbound calls.
    /// </summary>
    public class OutboundRouteGrant
    {
        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        public Guid RouteSourceId { get; set; }

        public int Channels { get; set; }

        public DateTime StartUtc { get; set; }

        public DateTime ExpirationUtc { get; set; }

        public OutboundAdministrativeState AdministrativeState { get; set; } = OutboundAdministrativeState.Enabled;

        public long Revision { get; set; }

        public string? ValidityOwner { get; set; }

        public string? SourceSystem { get; set; }

        public string? ExternalContractLineId { get; set; }

        public long? SourceVersion { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }

        public bool IsEligibleAt(DateTime utcNow)
            => Channels > 0
                && AdministrativeState == OutboundAdministrativeState.Enabled
                && OutboundValidity.Contains(StartUtc, ExpirationUtc, utcNow);
    }
}
