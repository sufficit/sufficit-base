using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Context-scoped snapshot of an outbound physical route imported into the experimental catalog.
    /// </summary>
    public class OutboundRouteRule
    {
        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        public string RouteProfile { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string? LegacyGroup { get; set; }

        public string? DestinationClass { get; set; }

        public OutboundRouteRuleMatchMode MatchMode { get; set; } = OutboundRouteRuleMatchMode.UNKNOWN;

        public int Priority { get; set; } = 100;

        public bool Enabled { get; set; } = true;

        public string Technology { get; set; } = "PJSIP";

        public int Timeout { get; set; } = 30;

        public string? Options { get; set; }

        public string? Url { get; set; }

        public string? Prepend { get; set; }

        public int Remove { get; set; }

        public string? Model { get; set; }

        public bool? LegacyIdForward { get; set; }

        public Guid? ProviderId { get; set; }

        public string? Servers { get; set; }

        public string? Comments { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }
    }
}
