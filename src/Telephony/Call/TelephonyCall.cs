using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Call
{
    public class TelephonyCall : IKey
    {
        /// <summary>
        ///     Asterisk Channel LinkedId
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; } = default!;

        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ContextId { get; set; }

        [JsonPropertyName("direction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CallDirection Direction { get; set; }

        [JsonPropertyName("destination")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Destination { get; set; }

        [JsonPropertyName("calleridnum")]
        public string CallerIdNum { get; set; } = default!;

        [JsonPropertyName("calleridname")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? CallerIdName { get; set; }

        [JsonPropertyName("disposition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TelephonyCallDisposition Disposition { get; set; }

        /// <inheritdoc cref="TelephonyCallState"/>
        [JsonPropertyName("state")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TelephonyCallState State { get; set; }

        [JsonPropertyName("hangup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public HangupInfo? Hangup { get; set; }

        [JsonPropertyName("recording")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Recording { get; set; }

        [JsonPropertyName("start")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTimeOffset? Start { get; set; }

        [JsonPropertyName("end")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTimeOffset? End { get; set; }

        #region EXTRA - CALCULATED PROPERTIES

        /// <summary>
        /// Gets or sets the duration of the operation in seconds.
        /// </summary>
        [JsonPropertyName("duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Duration { get; set; }

        #endregion
        #region DEBUG

        /// <summary>
        ///     Secondary channels associated with this call.
        /// </summary>
        [JsonPropertyName("channels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<string> Channels { get; set; } = default!;

        [JsonPropertyName("generation")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TelephonyCallGenerationMethod Generation { get; set; }

        #endregion
    }
}
