using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.CallDispatch
{
    /// <summary>
    /// Persists one concrete attempt linked to a call dispatch execution.
    /// The first cut keeps a single initial attempt but the model already supports sequential retries.
    /// </summary>
    public class CallDispatchAttempt
    {
        /// <summary>
        /// Unique attempt row identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Parent dispatch identifier matching <see cref="CallDispatchExecution.Id"/>.
        /// </summary>
        [JsonPropertyName("dispatch_id")]
        public Guid DispatchId { get; set; }

        /// <summary>
        /// Tenant context that owns the attempt.
        /// </summary>
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Optional identifier of the dedicated Call Dispatch configuration selected for the parent execution.
        /// </summary>
        [JsonPropertyName("call_dispatch_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? CallDispatchId { get; set; }

        /// <summary>
        /// Sequential number of the attempt within the same dispatch.
        /// </summary>
        [JsonPropertyName("attempt_number")]
        public int AttemptNumber { get; set; }

        /// <summary>
        /// Destination snapshot used by the attempt.
        /// </summary>
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = string.Empty;

        /// <summary>
        /// Optional Asterisk endpoint/extension snapshot used by the attempt.
        /// </summary>
        [JsonPropertyName("asterisk")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Asterisk { get; set; }

        /// <summary>
        /// Optional flag that indicates whether answering machine detection was requested for this attempt.
        /// Null means the feature is disabled.
        /// </summary>
        [JsonPropertyName("amd")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Amd { get; set; }

        /// <summary>
        /// Current lifecycle status of the attempt.
        /// </summary>
        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CallDispatchAttemptStatus Status { get; set; }

        /// <summary>
        /// UTC instant when the attempt row was created.
        /// </summary>
        [JsonPropertyName("created_at_utc")]
        public DateTime CreatedAtUtc { get; set; }

        /// <summary>
        /// UTC instant when runtime execution effectively started.
        /// </summary>
        [JsonPropertyName("started_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? StartedAtUtc { get; set; }

        /// <summary>
        /// UTC instant when the attempt reached a terminal state.
        /// </summary>
        [JsonPropertyName("finished_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? FinishedAtUtc { get; set; }

        /// <summary>
        /// Optional runtime message captured from the originate flow.
        /// </summary>
        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Message { get; set; }

        /// <summary>
        /// Optional runtime error captured from the originate flow.
        /// </summary>
        [JsonPropertyName("error")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Error { get; set; }

        /// <summary>
        /// Persistence version timestamp maintained by the EF row mapping.
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Timestamp { get; set; }
    }
}