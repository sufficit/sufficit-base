using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Monitor
{
    /// <summary>
    /// Request used to start a live call monitoring action from the web panel.
    /// </summary>
    public class TelephonyMonitorActionRequest
    {
        /// <summary>
        /// Tenant context that owns the monitored call.
        /// </summary>
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Monitor action mode requested by the supervisor.
        /// </summary>
        [JsonPropertyName("mode")]
        public TelephonyMonitorActionMode Mode { get; set; }

        /// <summary>
        /// Supervisor extension that must be called before the spy application starts.
        /// Example: 1001.
        /// </summary>
        [JsonPropertyName("supervisor_extension")]
        public string SupervisorExtension { get; set; } = string.Empty;

        /// <summary>
        /// Optional full supervisor channel. When empty, the backend uses <see cref="SupervisorProtocol"/>/<see cref="SupervisorExtension"/>.
        /// Example: PJSIP/1001.
        /// </summary>
        [JsonPropertyName("supervisor_channel")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SupervisorChannel { get; set; }

        /// <summary>
        /// Protocol used to build the supervisor channel when <see cref="SupervisorChannel"/> is not provided.
        /// </summary>
        [JsonPropertyName("supervisor_protocol")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SupervisorProtocol { get; set; }

        /// <summary>
        /// Target peer key shown by the realtime monitor. Example: PJSIP/2001.
        /// </summary>
        [JsonPropertyName("target_peer_key")]
        public string TargetPeerKey { get; set; } = string.Empty;

        /// <summary>
        /// Optional active channel key for a more precise ChanSpy target. Example: PJSIP/2001-000000af.
        /// </summary>
        [JsonPropertyName("target_channel_key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TargetChannelKey { get; set; }

        /// <summary>
        /// Optional AMI node/server identifier for multi-node deployments.
        /// </summary>
        [JsonPropertyName("node")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Node { get; set; }

        /// <summary>
        /// Optional caller id for the supervisor leg.
        /// </summary>
        [JsonPropertyName("callerid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CallerId { get; set; }

        /// <summary>
        /// Optional originate timeout in milliseconds.
        /// </summary>
        [JsonPropertyName("timeout")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Timeout { get; set; }
    }
}
