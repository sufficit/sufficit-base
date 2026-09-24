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

        /// <summary>
        ///     Session identifier of a WhatsApp number owned by this context.
        ///     This is an inventory reference, never a credential.
        /// </summary>
        public string? WhatsAppSessionId { get; set; }

        /// <summary>
        ///     Optional Asterisk-style destination pattern used to select this source.
        ///     Empty means any destination; it never rewrites dialed digits.
        /// </summary>
        public string? DialPattern { get; set; }

        public string? DestinationClass { get; set; }

        public OutboundRouteRuleMatchMode MatchMode { get; set; } = OutboundRouteRuleMatchMode.UNKNOWN;

        public Guid? ProviderId { get; set; }

        public int Priority { get; set; } = 100;

        public bool Enabled { get; set; } = true;

        /// <summary>
        ///     Include an inactive customer service when selecting this route in the preview.
        ///     This does not grant an active entitlement or authorize a real call.
        /// </summary>
        public bool IncludeInactiveServiceInSimulation { get; set; }

        public string? Servers { get; set; }

        public string? Comments { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }
    }
}
