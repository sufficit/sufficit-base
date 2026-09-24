using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Safe, context-scoped inventory option for the customer's outbound route set.
    ///     Status describes the underlying registration or contract, not live outbound readiness.
    /// </summary>
    public class OutboundRouteSourceCandidate
    {
        public OutboundRouteSourceKind Kind { get; set; }

        public Guid? ServiceId { get; set; }

        public string? WhatsAppSessionId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
