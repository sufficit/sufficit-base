using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.CallDispatch
{
    /// <summary>
    /// Canonical API request used to start one outbound call dispatch execution.
    /// It intentionally keeps only the fields needed to reconstruct <see cref="ExternalCallRequest"/> in the worker.
    /// </summary>
    public class CallDispatchRequest
    {
        /// <summary>
        /// Tenant context that owns the requested outbound call.
        /// </summary>
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Optional identifier of a persisted dispatch preset.
        /// The runtime accepts either this configuration id or an explicit <see cref="Asterisk"/> destination in the same request.
        /// </summary>
        [JsonPropertyName("call_dispatch_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? CallDispatchId { get; set; }

        /// <summary>
        /// Dialable destination informed by the caller.
        /// The standard service will normalize it before persistence when possible.
        /// </summary>
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = string.Empty;

        /// <summary>
        /// Explicit internal Asterisk destination that the answered call must follow.
        /// Example for local audio validation: 'sufficit-app-call-dispatch,announcement,1'.
        /// The runtime accepts either this value or <see cref="CallDispatchId"/>.
        /// </summary>
        [JsonPropertyName("asterisk")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Asterisk { get; set; }

        /// <summary>
        /// Optional external correlation id passed through the original telephony workflow.
        /// </summary>
        [JsonPropertyName("external_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ExternalId { get; set; }

        /// <summary>
        /// Optional operator-facing label or source hint for the dispatch.
        /// </summary>
        [JsonPropertyName("label")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }

        /// <summary>
        /// Optional delay in milliseconds for the underlying originate flow.
        /// </summary>
        [JsonPropertyName("delay")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Delay { get; set; }

        /// <summary>
        /// Indicates whether the legacy callback flow must prefix the external destination with zero.
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
        /// Optional flag that enables answering machine detection in the downstream callback flow.
        /// Null means the feature is disabled for this dispatch.
        /// </summary>
        [JsonPropertyName("amd")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Amd { get; set; }
    }
}