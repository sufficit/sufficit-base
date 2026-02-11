using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Sufficit.Audio;

namespace Sufficit.Telephony.Audio
{
    /// <summary>
    /// Audio file information including upload date and associated events.
    /// Uses composition to include audio format data from FFMpeg analysis.
    /// </summary>
    public class AudioFileInfo
    {
        /// <summary>
        /// Audio format data from FFMpeg analysis (duration, bitrate, codec, etc.)
        /// </summary>
        [JsonPropertyName("format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AudioFormatExtended? Format { get; set; }

        /// <summary>
        /// Date and time of upload
        /// </summary>
        [JsonPropertyName("upload")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Upload { get; set; }

        /// <summary>
        /// Audio file size in human readable format (e.g., "1.5 MB", "320 KB")
        /// </summary>
        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Size { get; set; }
        
        /// <summary>
        /// Format name (e.g., "mp3", "wav", "ogg", "flac").
        /// Available from FFProbe MediaFormat analysis.
        /// </summary>
        [JsonPropertyName("format_name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FormatName { get; set; }

        /// <summary>
        /// File size in bytes.
        /// Available from FFProbe MediaFormat analysis.
        /// </summary>
        [JsonPropertyName("file_size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? FileSize { get; set; }

        /// <summary>
        /// Events associated with this audio file
        /// </summary>
        [JsonPropertyName("events")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<string>? Events { get; set; }
    }
}
