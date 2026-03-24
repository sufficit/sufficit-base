using System.Text.Json.Serialization;

namespace Sufficit.Gateway.Zabbix
{
    /// <summary>
    /// Input payload received by the alert start endpoint.
    /// It carries the operational context needed by the standard start workflow to persist the initial execution snapshot.
    /// </summary>
    public class ZabbixAlertStartRequest
    {
        /// <summary>
        /// External event identifier sent by Zabbix.
        /// Persisted into <see cref="ZabbixAlertExecution.SourceEventId"/> for traceability and future deduplication.
        /// </summary>
        [JsonPropertyName("source_event_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? SourceEventId { get; set; }

        /// <summary>
        /// Monitored host or entity name associated with the alert.
        /// Used today in the execution snapshot and flap-key generation.
        /// </summary>
        [JsonPropertyName("host")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Host { get; set; }

        /// <summary>
        /// Human-readable trigger title supplied by Zabbix.
        /// Persisted for status/history and combined into the anti-flapping fingerprint.
        /// </summary>
        [JsonPropertyName("trigger")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Trigger { get; set; }

        /// <summary>
        /// Severity label reported by Zabbix.
        /// Stored in the execution row and used in the flap fingerprint.
        /// </summary>
        [JsonPropertyName("severity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Severity { get; set; }

        /// <summary>
        /// Short subject prepared by the alert source.
        /// Reserved for future voice/text rendering while already being persisted with the execution.
        /// </summary>
        [JsonPropertyName("subject")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Subject { get; set; }

        /// <summary>
        /// Optional long-form message body from Zabbix.
        /// Not persisted yet, but kept in the start contract for the upcoming dispatch/narration stage.
        /// </summary>
        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Message { get; set; }
    }
}