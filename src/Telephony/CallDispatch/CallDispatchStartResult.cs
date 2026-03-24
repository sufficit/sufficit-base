using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.CallDispatch
{
    /// <summary>
    /// Result returned by the start endpoint after persistence and queue publication.
    /// </summary>
    public class CallDispatchStartResult
    {
        /// <summary>
        /// Indicates whether the start request was accepted.
        /// </summary>
        [JsonPropertyName("accepted")]
        public bool Accepted { get; set; }

        /// <summary>
        /// Public identifier of the persisted dispatch execution.
        /// </summary>
        [JsonPropertyName("dispatch_id")]
        public Guid DispatchId { get; set; }

        /// <summary>
        /// Tenant context that owns the accepted dispatch.
        /// </summary>
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Effective destination persisted for the worker.
        /// </summary>
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = string.Empty;

        /// <summary>
        /// Initial lifecycle state after synchronous persistence.
        /// </summary>
        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CallDispatchExecutionStatus Status { get; set; }

        /// <summary>
        /// Human-readable message describing the synchronous outcome.
        /// </summary>
        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Message { get; set; }
    }
}