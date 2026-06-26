using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Monitor
{
    /// <summary>
    /// Result returned after a monitor action originate request is submitted to AMI.
    /// </summary>
    public class TelephonyMonitorActionResult
    {
        /// <summary>
        /// Indicates whether the manager accepted the action.
        /// </summary>
        [JsonPropertyName("accepted")]
        public bool Accepted { get; set; }

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
        /// AMI ActionId generated for correlation.
        /// </summary>
        [JsonPropertyName("action_id")]
        public string ActionId { get; set; } = string.Empty;

        /// <summary>
        /// Supervisor channel used by the originate action.
        /// </summary>
        [JsonPropertyName("supervisor_channel")]
        public string SupervisorChannel { get; set; } = string.Empty;

        /// <summary>
        /// ChanSpy target used by the dialplan.
        /// </summary>
        [JsonPropertyName("spy_target")]
        public string SpyTarget { get; set; } = string.Empty;

        /// <summary>
        /// AMI response text.
        /// </summary>
        [JsonPropertyName("response")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Response { get; set; }

        /// <summary>
        /// AMI message text.
        /// </summary>
        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }
    }
}
