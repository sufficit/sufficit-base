using System;
using System.Text.Json.Serialization;
using Sufficit;

namespace Sufficit.Telephony.CallForward
{
    /// <summary>
    /// Search parameters for <see cref="CallForwardApplication"/> queries.
    /// </summary>
    public class CallForwardSearchParameters : ILimit, IIncrementalTrackingSearchParameters
    {
        public const string CALLFORWARDID = "callforwardid";
        public const string CONTEXTID = "contextid";
        public const string TITLE = "title";

        [JsonPropertyName(CALLFORWARDID)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? CallForwardId { get; set; }

        [JsonPropertyName(CONTEXTID)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }

        [JsonPropertyName(TITLE)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TextFilter? Title { get; set; }

        [JsonPropertyName("destination")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TextFilter? Destination { get; set; }

        /// <inheritdoc cref="IIncrementalTrackingSearchParameters.Timestamp"/>
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TimestampFilter? Timestamp { get; set; }

        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public uint? Limit { get; set; }

        /// <inheritdoc cref="IIncrementalTrackingSearchParameters.Deleted"/>
        [JsonPropertyName("deleted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Deleted { get; set; }
    }
}
