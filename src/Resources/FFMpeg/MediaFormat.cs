using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.FFMpeg
{
    public class MediaFormat
    {
        /// <summary>
        ///     File name or Pipe name
        /// </summary>
        [JsonPropertyName("filename")]
        public string FileName { get; set; } = default!;

        [JsonPropertyName("nb_streams")]
        public uint Streams { get; set; }

        [JsonPropertyName("nb_programs")]
        public uint Programs { get; set; }

        [JsonPropertyName("nb_stream_groups")]
        public uint StreamGroups { get; set; }

        [JsonPropertyName("format_name")]
        public string FormatName { get; set; } = default!;

        [JsonPropertyName("format_long_name")]
        public string FormatLongName { get; set; } = default!;

        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonPropertyName("duration")]
        public double Duration { get; set; }

        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonPropertyName("start_time")]
        public double StartTime { get; set; }

        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonPropertyName("size")]
        public uint Size { get; set; }

        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonPropertyName("bit_rate")]
        public uint BitRate { get; set; }

        [JsonPropertyName("probe_score")]
        public uint ProbeScore { get; set; }

        [JsonPropertyName("tags")]
        public dynamic? Tags { get; set; }
    }
}
