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

        public TimeSpan? TimeOut { get; set; }
    }
}
