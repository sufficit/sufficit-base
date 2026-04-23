using System;
using System.Text.Json.Serialization;
using Sufficit;

namespace Sufficit.Telephony.IVR
{
    /// <summary>
    /// IVRMenu option search parameters.
    /// </summary>
    public class IVROptionSearchParameters : ILimit, IIncrementalTrackingSearchParameters
    {
        [JsonPropertyName("ivrid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? IVRId { get; set; }

        [JsonPropertyName("digits")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TextFilter? Digits { get; set; }

        /// <inheritdoc cref="IIncrementalTrackingSearchParameters.Timestamp"/>
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TimestampFilter? Timestamp { get; set; }

        /// <inheritdoc cref="IIncrementalTrackingSearchParameters.Deleted"/>
        [JsonPropertyName("deleted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Deleted { get; set; }

        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public uint? Limit { get; set; }
    }
}
