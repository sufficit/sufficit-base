using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.FFMpeg
{
    /// <summary>
    ///     Represents a media stream information from FFProbe output.
    ///     Contains detailed technical properties about an audio or video stream.
    /// </summary>
    public class StreamInfo
    {
        /// <summary>
        ///     Stream index position in the media file (0-based)
        /// </summary>
        [JsonPropertyName("index")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public uint Index { get; set; }

        /// <summary>
        ///     Codec name used to encode the stream (e.g., "pcm_s16le", "mp3", "aac", "h264")
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("codec_name")]
        public string CodecName { get; set; } = default!;

        /// <summary>
        ///     Type of codec stream: "audio", "video", "subtitle", or "data"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("codec_type")]
        public string CodecType { get; set; } = default!;

        /// <summary>
        ///     Number of audio channels (1=mono, 2=stereo, 6=5.1 surround, etc.)
        /// </summary>
        [JsonPropertyName("channels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public uint Channels { get; set; }

        /// <summary>
        ///     Duration of the stream in seconds
        /// </summary>
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("duration")]
        public double Duration { get; set; }

        /// <summary>
        ///     Sample rate in Hz (e.g., 8000, 16000, 44100, 48000)
        /// </summary>
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("sample_rate")]
        public uint SampleRate { get; set; }

        /// <summary>
        ///     Bit rate of the stream in bits per second (bps)
        /// </summary>
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("bit_rate")]
        public uint BitRate { get; set; }

        /// <summary>
        ///     Number of bits per audio sample (e.g., 8, 16, 24, 32)
        /// </summary>
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("bits_per_sample")]
        public ushort BitsPerSample { get; set; }

        /// <summary>
        ///     Additional properties from FFProbe output not explicitly mapped
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object>? Extra { get; set; }
    }
}
