using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Channel hangup information
    /// </summary>
    public class HangupInfo
    {
        /// <summary>
        ///     Asterisk Hangup Cause Code
        /// </summary>
        [JsonPropertyName("cause")]
        public uint Cause { get; set; }

        /// <summary>
        ///     Asterisk Hangup Cause Text
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; } = default!;

        /// <summary>
        ///     System comments about the hangup
        /// </summary>
        [JsonPropertyName("comments")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Comments { get; set; }
    }
}
