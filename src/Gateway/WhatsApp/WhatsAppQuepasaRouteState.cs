namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Live Quepasa connection state for one persisted route — separate from
    /// <see cref="WhatsAppQuepasaStatusResponse"/> (which polls the wizard's own in-progress
    /// pairing session) because routes can be provisioned outside that flow and aren't
    /// identifiable by a context-derived token; this is looked up by phone number instead.
    /// </summary>
    public class WhatsAppQuepasaRouteState
    {
        /// <summary>Echoes <see cref="WhatsAppGatewayRoute.SessionId"/> so the UI can match rows.</summary>
        public string SessionId { get; set; } = string.Empty;

        /// <summary>Raw whatsmeow/Quepasa connection state string (e.g. "Ready", "Disconnected").</summary>
        public string? State { get; set; }

        /// <summary>True once Quepasa confirms the session is actually paired/verified.</summary>
        public bool Connected { get; set; }

        /// <summary>
        /// True only when the session's call policy resolves to "process" — the one value that
        /// actually activates VoIP call routing (quepasa's voip/manager.go "master gate"). QR/pair-code
        /// pairing never sets this on its own; false here means calls are silently dead even though
        /// messaging works fine.
        /// </summary>
        public bool CallsEnabled { get; set; }

        /// <summary>"disabled", "exclusive" or "additional" — see quepasa's whatsapp_voipmode.go. Null when unknown.</summary>
        public string? VoipMode { get; set; }

        /// <summary>
        /// True when WhatsApp message processing is explicitly off for this session — the state
        /// every route managed from here should be in, since this panel routes calls and nothing
        /// consumes the messages. False means Quepasa is still receiving, storing and dispatching
        /// every message on the number for no one.
        /// </summary>
        public bool MessagesDisabled { get; set; }
    }
}
