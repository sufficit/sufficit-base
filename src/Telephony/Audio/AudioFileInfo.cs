using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Audio
{
    public class AudioFileInfo
    {
        /// <summary>
        ///     Audio duration in seconds
        /// </summary>
        [JsonPropertyName("duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double Duration { get; set; }

        /// <summary>
        ///     Date and time of upload
        /// </summary>
        [JsonPropertyName("upload")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Upload { get; set; }

        [JsonPropertyName("format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Format { get; set; }

        /// <summary>
        ///    Audio file size in human readable format
        /// </summary>
        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Size { get; set; }

        [JsonPropertyName("bitrate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public uint? BitRate { get; set; }

        [JsonPropertyName("events")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<string>? Events { get; set; }
    }
}
