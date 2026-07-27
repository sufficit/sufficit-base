using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// One WhatsApp (Quepasa) VoIP call currently in progress, as served by the calls snapshot
    /// endpoint. Deliberately mirrors the realtime "calls.update" payload field-for-field MINUS
    /// the session token, so the monitor screen can seed its table from a snapshot and then keep
    /// applying realtime events to the very same rows.
    ///
    /// The snapshot exists because Quepasa only publishes call events on state transitions
    /// (start / state change / end) with no heartbeat: a call that was already connected when the
    /// screen opened produces no event at all until it ends, so a purely event-driven view shows
    /// an empty table while calls are visibly in progress.
    /// </summary>
    public class WhatsAppQuepasaActiveCall
    {
        /// <summary>Quepasa's own call id — stable for the call's lifetime, the key realtime updates arrive under.</summary>
        [JsonPropertyName("callid")]
        public string CallId { get; set; } = string.Empty;

        /// <summary>"inbound" (WhatsApp to SIP) or "outbound" (SIP to WhatsApp).</summary>
        [JsonPropertyName("direction")]
        public string Direction { get; set; } = string.Empty;

        [JsonPropertyName("fromphone")]
        public string FromPhone { get; set; } = string.Empty;

        [JsonPropertyName("tophone")]
        public string ToPhone { get; set; } = string.Empty;

        [JsonPropertyName("callername")]
        public string CallerName { get; set; } = string.Empty;

        /// <summary>
        /// The owning session's id, matching <see cref="WhatsAppGatewayRoute.SessionId"/>. The
        /// session TOKEN is intentionally absent — it is a credential and never leaves the server.
        /// </summary>
        [JsonPropertyName("sessionid")]
        public string SessionId { get; set; } = string.Empty;

        /// <summary>
        /// Raw call phase from Quepasa's VoIP engine: initiated, inviting, proceeding, accepted,
        /// rejected, timeout, cancelled.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;

        [JsonPropertyName("starttime")]
        public DateTime? StartTime { get; set; }

        [JsonPropertyName("lastupdate")]
        public DateTime? LastUpdate { get; set; }

        /// <summary>Point-in-time duration snapshot; live views should tick from <see cref="StartTime"/> instead.</summary>
        [JsonPropertyName("durationms")]
        public long DurationMs { get; set; }

        /// <summary>
        /// Tenant the call belongs to, resolved server-side from the owning route. Empty when the
        /// session has no Sufficit route linked (in which case the call is not shown to anyone but
        /// a manager watching every context).
        /// </summary>
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }
    }
}
