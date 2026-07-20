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
    }
}
