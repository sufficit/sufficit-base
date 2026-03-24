using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.CallDispatch
{
    /// <summary>
    /// Minimal RabbitMQ payload used to trigger worker processing for one persisted dispatch.
    /// </summary>
    public sealed class CallDispatchQueueEvent
    {
        /// <summary>
        /// Identifier of the persisted dispatch execution to process.
        /// </summary>
        [JsonPropertyName("dispatch_id")]
        public Guid DispatchId { get; set; }

        /// <summary>
        /// Tenant context expected by the worker for logging and safety checks.
        /// </summary>
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }
    }
}