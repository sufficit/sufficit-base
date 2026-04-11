using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.CallDispatch
{
    /// <summary>
    /// Search contract for persisted Call Dispatch executions.
    /// Used by the monitoring API and Blazor UI to list recent dispatch activity.
    /// </summary>
    public class CallDispatchExecutionSearchParameters : ILimit
    {
        /// <summary>
        /// Optional direct filter by the public dispatch identifier.
        /// </summary>
        [JsonPropertyName("dispatch_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? DispatchId { get; set; }

        /// <summary>
        /// Optional tenant context filter.
        /// </summary>
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }

        /// <summary>
        /// Optional preset filter.
        /// </summary>
        [JsonPropertyName("call_dispatch_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? CallDispatchId { get; set; }

        /// <summary>
        /// Optional text filter for the external destination.
        /// </summary>
        [JsonPropertyName("destination")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public global::Sufficit.TextFilter? Destination { get; set; }

        /// <summary>
        /// Optional text filter for the resolved internal Asterisk destination.
        /// </summary>
        [JsonPropertyName("asterisk")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public global::Sufficit.TextFilter? Asterisk { get; set; }

        /// <summary>
        /// Optional execution status filter.
        /// </summary>
        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public CallDispatchExecutionStatus? Status { get; set; }

        /// <summary>
        /// Maximum number of execution rows returned.
        /// The provider applies this after ordering by most recent activity first.
        /// </summary>
        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public uint? Limit { get; set; } = 50;
    }
}