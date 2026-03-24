using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.CallDispatch
{
    /// <summary>
    /// Persists the lifecycle of one call dispatch execution.
    /// The database row is the operational source of truth while RabbitMQ carries only the work trigger.
    /// </summary>
    public class CallDispatchExecution
    {
        /// <summary>
        /// Public dispatch identifier returned by the API and reused by attempt rows.
        /// </summary>
        [JsonPropertyName("dispatch_id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Tenant context that owns the dispatch.
        /// </summary>
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Normalized dialable destination snapshot used by the worker.
        /// </summary>
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = string.Empty;

        /// <summary>
        /// Optional Asterisk endpoint/extension snapshot used by the originate flow.
        /// </summary>
        [JsonPropertyName("asterisk")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Asterisk { get; set; }

        /// <summary>
        /// Optional external correlation id inherited from the request.
        /// </summary>
        [JsonPropertyName("external_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ExternalId { get; set; }

        /// <summary>
        /// Optional operator-facing label inherited from the request.
        /// </summary>
        [JsonPropertyName("label")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }

        /// <summary>
        /// Optional delay in milliseconds used by the underlying callback/originate flow.
        /// </summary>
        [JsonPropertyName("delay")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Delay { get; set; }

        /// <summary>
        /// Indicates whether the runtime flow should use the alternative routing prefix behavior.
        /// </summary>
        [JsonPropertyName("alternative")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Alternative { get; set; }

        /// <summary>
        /// Optional compatibility flag forwarded to the runtime request.
        /// </summary>
        [JsonPropertyName("await")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Await { get; set; }

        /// <summary>
        /// Optional flag that enables answering machine detection for this dispatch execution.
        /// Null means the feature is disabled.
        /// </summary>
        [JsonPropertyName("amd")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Amd { get; set; }

        /// <summary>
        /// Current lifecycle status of the execution.
        /// </summary>
        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CallDispatchExecutionStatus Status { get; set; }

        /// <summary>
        /// UTC instant when the dispatch was first accepted and persisted.
        /// </summary>
        [JsonPropertyName("created_at_utc")]
        public DateTime CreatedAtUtc { get; set; }

        /// <summary>
        /// UTC instant when worker processing effectively started.
        /// </summary>
        [JsonPropertyName("started_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? StartedAtUtc { get; set; }

        /// <summary>
        /// UTC instant when the execution reached a terminal state.
        /// </summary>
        [JsonPropertyName("finished_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? FinishedAtUtc { get; set; }

        /// <summary>
        /// Last runtime error message captured for the execution.
        /// </summary>
        [JsonPropertyName("error")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Error { get; set; }

        /// <summary>
        /// Last success/info message captured for the execution.
        /// </summary>
        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Message { get; set; }

        /// <summary>
        /// Persistence version timestamp maintained by the EF row mapping.
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Timestamp { get; set; }
    }
}