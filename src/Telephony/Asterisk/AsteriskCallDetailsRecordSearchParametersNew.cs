using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Asterisk
{
    public class AsteriskCallDetailsRecordSearchParametersNew
    {
        /// <summary>
        /// Date and time for search interval to start. <br />
        /// If not set, the search process will proceed from the end backwards.
        /// </summary>
        /// <remarks>* Most servers uses UTC, remember to threat offset before using</remarks>
        [JsonPropertyName("start")]
        public DateTimeRangeNew? Start { get; set; }

        /// <summary>
        /// Date and time for search interval to end. <br />
        /// If not set, the search process will proceed from the beginning forward.
        /// </summary>
        /// <remarks>* Most servers uses UTC, remember to threat offset before using</remarks>
        [JsonPropertyName("end")]
        public DateTimeRangeNew? End { get; set; }

        /// <summary>
        /// Optional ordering for the records query. When null the provider keeps its
        /// default ordering (most recent first), so existing callers are unaffected.
        /// </summary>
        /// <remarks>
        /// <see cref="SortingParameters.Text"/> must name a property of
        /// <see cref="AsteriskCallDetailsRecord"/>, for example
        /// <c>nameof(AsteriskCallDetailsRecord.linkedid)</c>. Ordering by linkedid makes the
        /// records of a call contiguous, which lets consumers consolidate them while
        /// streaming instead of buffering the whole result set.
        /// </remarks>
        [JsonPropertyName("sorting")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SortingParameters? Sorting { get; set; }

        /// <inheritdoc cref="AMAFlags"/>
        [JsonPropertyName("amaflags")]
        public AMAFlags? AMAFlags { get; set; }

        /// <summary>
        ///     Search for exact match dids or not setted for array empty
        /// </summary>
        [JsonPropertyName("dids")]
        public string[]? DIDs { get; set; }

        [JsonPropertyName("linkedid")]
        public TextFilter? LinkedId { get; set; }

        [JsonPropertyName("limit")]
        public uint Limit { get; set; }

        /// <summary>
        ///     Search for the exact accountcode specified, so remember to trim spaces if necessary, it is useful for searching for empty ones
        /// </summary>
        [JsonPropertyName("accountcode")]
        public TextFilter? AccountCode { get; set; }

        /// <summary>
        ///     Filter by originating channel name substring (e.g. carrier trunk token).
        /// </summary>
        [JsonPropertyName("channel")]
        public TextFilter? Channel { get; set; }

        /// <summary>
        ///     Filter by destination channel name substring (e.g. carrier trunk token).
        /// </summary>
        [JsonPropertyName("dstchannel")]
        public TextFilter? DstChannel { get; set; }

        /// <summary>
        ///     
        /// </summary>
        [JsonPropertyName("channels")]
        public TextFilter? Channels { get; set; }

        public TimeSpan? TimeOut { get; set; }
    }
}
