using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.Zabbix
{
    /// <summary>
    /// Persists the lifecycle of a single Zabbix alert start request.
    /// Written by the standard Zabbix gateway start workflow and stored by the EF Zabbix gateway provider in <c>gatw_zabbix_executions</c>.
    /// </summary>
    public class ZabbixAlertExecution
    {
        /// <summary>
        /// Correlation identifier exposed to the caller as <c>alert_id</c> and reused by child attempt rows.
        /// </summary>
        [JsonPropertyName("alert_id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Tenant context that owns the execution.
        /// Used by start validation in the standard provider and by EF indexes for scoped queries.
        /// </summary>
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Identifier of the configured Zabbix integration that accepted this alert.
        /// Filled from the controller query string <c>id</c> after the integration ownership check succeeds.
        /// </summary>
        [JsonPropertyName("integration_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid IntegrationId { get; set; }

        /// <summary>
        /// Original event identifier received from Zabbix, when available.
        /// Intended for idempotency, traceability and future deduplication checks.
        /// </summary>
        [JsonPropertyName("source_event_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? SourceEventId { get; set; }

        /// <summary>
        /// Host name or monitored entity name sent by Zabbix.
        /// Currently used to compose the flap fingerprint and future operator-facing status views.
        /// </summary>
        [JsonPropertyName("host")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Host { get; set; }

        /// <summary>
        /// Human-readable trigger/problem title received on alert start.
        /// Combined with host and severity by the standard provider to generate <see cref="FlapKey"/>.
        /// </summary>
        [JsonPropertyName("trigger")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Trigger { get; set; }

        /// <summary>
        /// Severity label reported by Zabbix for this execution.
        /// Also participates in the anti-flapping fingerprint produced during start.
        /// </summary>
        [JsonPropertyName("severity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Severity { get; set; }

        /// <summary>
        /// Short subject prepared for notification or call narration.
        /// Persisted now so the future dispatch stage can reuse it without depending on the original request body.
        /// </summary>
        [JsonPropertyName("subject")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Subject { get; set; }

        /// <summary>
        /// Outbound caller identifier effectively selected for the alert.
        /// It contains either the tenant DID validated during start or the integration fallback identifier.
        /// </summary>
        [JsonPropertyName("identifier")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Identifier { get; set; }

        /// <summary>
        /// Indicates whether the execution relied on the platform default identifier instead of an integration-specific DID.
        /// Returned to the API caller and persisted for auditing of outbound caller selection.
        /// </summary>
        [JsonPropertyName("uses_default_identifier")]
        public bool UsesDefaultIdentifier { get; set; }

        /// <summary>
        /// Normalized fingerprint for anti-flapping decisions.
        /// Built from host, trigger and severity by the start workflow.
        /// </summary>
        [JsonPropertyName("flap_key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? FlapKey { get; set; }

        /// <summary>
        /// Current lifecycle state of the execution.
        /// Starts as <see cref="ZabbixAlertExecutionStatus.Validated"/> and is meant to evolve as dispatch is implemented.
        /// </summary>
        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ZabbixAlertExecutionStatus Status { get; set; }

        /// <summary>
        /// UTC instant when the alert start was accepted and persisted.
        /// Set by the synchronous start workflow before returning to the API caller.
        /// </summary>
        [JsonPropertyName("started_at_utc")]
        public DateTime StartedAtUtc { get; set; }

        /// <summary>
        /// UTC instant when execution processing ends.
        /// Reserved for the future dispatcher to mark completion, suppression or failure.
        /// </summary>
        [JsonPropertyName("finished_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? FinishedAtUtc { get; set; }

        /// <summary>
        /// Optional terminal error message for failed executions.
        /// Intended for operational diagnosis and future status endpoints.
        /// </summary>
        [JsonPropertyName("error")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Error { get; set; }

        /// <summary>
        /// Persistence version timestamp maintained by the database row mapping.
        /// Used by the standard AddOrUpdate provider pattern for optimistic tracking.
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Timestamp { get; set; }
    }
}