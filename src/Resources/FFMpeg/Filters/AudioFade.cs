using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.FFMpeg.Filters
{
    /// <summary>
    ///     afade=type=in:start_time=0:duration=5
    /// </summary>
    public class AudioFade
    {
        [JsonPropertyName("type")]
        public FadeType Type { get; set; }

        /// <summary>
        ///     Milliseconds
        /// </summary>
        [JsonPropertyName("start_time")]
        public uint StartTime { get; set; }

        /// <summary>
        ///     Milliseconds
        /// </summary>
        [JsonPropertyName("duration")]
        public uint Duration { get; set; }
    }

    public enum FadeType
    {
        [EnumMember(Value = "in")]
        IN,

        [EnumMember(Value = "out")]
        OUT
    }
}
