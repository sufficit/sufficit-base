using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Customer-facing ordered outbound source that may reference a Sufficit service or a customer interconnection.
    /// </summary>
    public class OutboundRouteSource
    {
        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        public OutboundRouteSourceKind Kind { get; set; } = OutboundRouteSourceKind.UNKNOWN;

        public Guid? ServiceId { get; set; }

        public Guid? InterconnectionId { get; set; }

        public string? DestinationClass { get; set; }

        public OutboundRouteRuleMatchMode MatchMode { get; set; } = OutboundRouteRuleMatchMode.UNKNOWN;

        public Guid? ProviderId { get; set; }

        public int Priority { get; set; } = 100;

        public bool Enabled { get; set; } = true;

        public string? Servers { get; set; }

        public string? Comments { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }
    }
}
