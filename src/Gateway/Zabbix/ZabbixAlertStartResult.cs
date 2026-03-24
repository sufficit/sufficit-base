using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.Zabbix
{
    /// <summary>
    /// Result returned by the start endpoint after validation and initial persistence.
    /// It mirrors the most relevant fields of <see cref="ZabbixAlertExecution"/> needed by the caller.
    /// </summary>
    public class ZabbixAlertStartResult
    {
        /// <summary>
        /// Indicates whether the request passed the current synchronous validation stage.
        /// Returned by the standard start workflow.
        /// </summary>
        [JsonPropertyName("accepted")]
        public bool Accepted { get; set; }

        /// <summary>
        /// Correlation identifier of the persisted execution row.
        /// Consumers should use this value to query future status/attempt endpoints.
        /// </summary>
        [JsonPropertyName("alert_id")]
        public Guid AlertId { get; set; }

        /// <summary>
        /// Tenant context that authorized the start request.
        /// Echoed back so callers can correlate the accepted execution scope.
        /// </summary>
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Identifier of the Zabbix integration used for the alert start.
        /// This is the same integration id received by the controller query string.
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Effective outbound caller identifier resolved for this execution.
        /// Contains the validated tenant DID or the integration/platform fallback.
        /// </summary>
        [JsonPropertyName("identifier")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Identifier { get; set; }

        /// <summary>
        /// Optional DTMF digit required to confirm alert receipt.
        /// Null means digit confirmation is disabled for the integration/execution.
        /// </summary>
        [JsonPropertyName("digit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public uint? Digit { get; set; }

        /// <summary>
        /// Tells the caller whether the platform default identifier was used.
        /// This mirrors <see cref="ZabbixAlertExecution.UsesDefaultIdentifier"/> for transparency.
        /// </summary>
        [JsonPropertyName("uses_default_identifier")]
        public bool UsesDefaultIdentifier { get; set; }

        /// <summary>
        /// Number of enabled destinations found for the integration at validation time.
        /// Calculated by the start workflow before the first dispatch attempt exists.
        /// </summary>
        [JsonPropertyName("validated_destination_count")]
        public int ValidatedDestinationCount { get; set; }

        /// <summary>
        /// Current execution status after the synchronous start phase.
        /// Today it is returned as <see cref="ZabbixAlertExecutionStatus.Validated"/> when validation succeeds.
        /// </summary>
        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ZabbixAlertExecutionStatus Status { get; set; }

        /// <summary>
        /// Human-readable outcome message for the caller.
        /// Used to distinguish normal validation from edge cases such as zero enabled destinations.
        /// </summary>
        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Message { get; set; }
    }
}