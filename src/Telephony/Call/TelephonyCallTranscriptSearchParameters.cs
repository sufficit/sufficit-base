using Sufficit;
using System;

namespace Sufficit.Telephony.Call
{
    /// <summary>
    /// Search parameters for call transcript records
    /// </summary>
    public class TelephonyCallTranscriptSearchParameters : SearchParameters, ILimit
    {
        /// <summary>
        /// Filter by transcript ID (Asterisk linkedid)
        /// </summary>
        public TextFilter? Id { get; set; }

        /// <summary>
        /// Filter by Whisper model used
        /// </summary>
        public TextFilter? Model { get; set; }

        /// <summary>
        /// Filter by timestamp range
        /// </summary>
        public DateTimeRangeNew? Timestamp { get; set; }

        /// <summary>
        /// Filter by expiration date range
        /// </summary>
        public DateTimeRangeNew? Expiration { get; set; }

        /// <summary>
        /// Search in transcript segments text
        /// </summary>
        public TextFilter? Text { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        [System.Text.Json.Serialization.JsonPropertyName("limit")]
        public uint? Limit { get; set; }
    }
}