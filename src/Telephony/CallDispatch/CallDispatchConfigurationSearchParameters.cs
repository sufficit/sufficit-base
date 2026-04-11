using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.CallDispatch
{
    /// <summary>
    /// Search contract for persisted Call Dispatch configuration presets.
    /// Used by the management API and Blazor UI to list presets for one telephony context.
    /// </summary>
    public class CallDispatchConfigurationSearchParameters : ILimit
    {
        /// <summary>
        /// Optional direct filter by the persisted preset identifier.
        /// </summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Optional tenant context filter.
        /// </summary>
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }

        /// <summary>
        /// Optional text filter for the friendly preset title.
        /// </summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public global::Sufficit.TextFilter? Title { get; set; }

        /// <summary>
        /// Optional text filter for the stored internal Asterisk destination.
        /// </summary>
        [JsonPropertyName("asterisk")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public global::Sufficit.TextFilter? Asterisk { get; set; }

        /// <summary>
        /// Maximum number of preset rows returned.
        /// </summary>
        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public uint? Limit { get; set; }
    }
}