using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.FFMpeg
{
    public class StreamInfo
    {
        /// <summary>
        ///     Stream index position
        /// </summary>
        [JsonPropertyName("index")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public uint Index { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("codec_name")]
        public string CodecName { get; set; } = default!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("codec_type")]
        public string CodecType { get; set; } = default!;

        /// <summary>
        ///     Number of channels (1=mono,2=stereo etc)
        /// </summary>
        [JsonPropertyName("channels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public uint Channels { get; set; }

        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("duration")]
        public double Duration { get; set; }

        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("sample_rate")]
        public uint SampleRate { get; set; }

        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("bit_rate")]
        public uint BitRate { get; set; }


        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("bits_per_sample")]
        public ushort BitsPerSample { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object>? Extra { get; set; }
    }
}
