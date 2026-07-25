using System;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Lay-readable diagnostic for one Quepasa session, sourced from Quepasa's own
    /// QpConnectionDiagnostic (GET /health). Distinct from <see cref="WhatsAppQuepasaRouteState"/>
    /// (bare connection state, polled per row) — this is fetched on demand when someone asks
    /// "why isn't this connected/why did it fail".
    /// </summary>
    public class WhatsAppQuepasaDiagnostic
    {
        /// <summary>Echoes <see cref="WhatsAppGatewayRoute.SessionId"/> so the caller can match it back.</summary>
        public string SessionId { get; set; } = string.Empty;

        /// <summary>False when the diagnostic itself could not be fetched (session/host unreachable).</summary>
        public bool Success { get; set; }

        /// <summary>Sentence form Quepasa always returns, e.g. "server state is Disconnected".</summary>
        public string? StatusText { get; set; }

        /// <summary>Raw connection state name (e.g. "Ready", "Disconnected").</summary>
        public string? State { get; set; }

        /// <summary>Machine code identifying the disconnect/logout cause, e.g. "logged_out_another_device".</summary>
        public string? Code { get; set; }

        public string? Message { get; set; }

        public string? SuggestedAction { get; set; }

        /// <summary>True when the session needs a fresh QR/pair-code pairing, not just a restart.</summary>
        public bool RequiresReauth { get; set; }

        public DateTime? OccurredAt { get; set; }
    }
}
