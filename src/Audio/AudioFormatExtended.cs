using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Audio
{
    /// <summary>
    /// Extended audio format information including duration, codec, and bitrate.
    /// Provides additional properties beyond basic format (channels, bits, rate) from base class.
    /// Populated from FFProbe stream analysis results.
    /// </summary>
    public class AudioFormatExtended : AudioFormat
    {
        /// <summary>
        /// Duration of the audio in seconds
        /// </summary>
        [JsonPropertyName("duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double Duration { get; set; }

        /// <summary>
        /// Audio codec name (e.g., "pcm_s16le", "mp3", "aac", "opus")
        /// </summary>
        [JsonPropertyName("codec")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Codec { get; set; } = default!;

        /// <summary>
        /// Bitrate of the audio stream in bits per second (bps).
        /// Available from FFProbe StreamInfo analysis.
        /// </summary>
        [JsonPropertyName("bit_rate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public long? BitRate { get; set; }

        public override bool Equals(object? obj)
            => obj is AudioFormatExtended other && other.Duration == Duration && other.Codec == Codec && other.BitRate == BitRate && base.Equals(other);

        public override int GetHashCode()
            => (Duration, Codec, BitRate, base.GetHashCode()).GetHashCode();
    }
}
