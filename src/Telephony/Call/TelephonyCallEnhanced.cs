using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Call
{
    public class TelephonyCallEnhanced : TelephonyCall
    {
        /// <summary>
        /// Gets or sets additional information related to the telephony call.
        /// </summary>
        [JsonPropertyName("extra")]
        [JsonPropertyOrder(99)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TelephonyCallExtras? Extra { get; set; }

        #region DEBUG

        /// <summary>
        ///     Secondary channels associated with this call.
        /// </summary>
        [JsonPropertyName("channels")]
        [JsonPropertyOrder(99)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<string> Channels { get; set; } = default!;

        [JsonPropertyName("generation")]
        [JsonPropertyOrder(99)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TelephonyCallGenerationMethod Generation { get; set; }

        #endregion


    }
}
