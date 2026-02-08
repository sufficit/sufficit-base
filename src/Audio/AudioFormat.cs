using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Audio
{
    /// <summary>
    /// Basic audio format information containing channels, bit depth, and sample rate.
    /// Base class for audio format representations.
    /// </summary>
    public class AudioFormat
    {
        /// <summary>
        ///     Number of channels (1=mono,2=stereo etc)
        /// </summary>
        [JsonPropertyName("channels")]
        [JsonPropertyOrder(-2)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint Channels { get; set; }

        /// <summary>
        ///     Number of bits per sample (usually 16 or 32, sometimes 24 or 8) Can be 0 for some codecs     
        /// </summary>
        [JsonPropertyName("bits")]
        [JsonPropertyOrder(-2)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ushort Bits { get; set; }

        /// <summary>
        ///     Samples per second, the audio frequency specified in Hz. "8000", "16000", "22050", and "24000"
        /// </summary>
        [JsonPropertyName("rate")]
        [JsonPropertyOrder(-2)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint Rate { get; set; }


        public override bool Equals(object? obj)
            => obj is AudioFormat other && other.Bits == Bits && other.Channels == Channels && other.Rate == Rate;

        public override int GetHashCode()
            => (Bits, Channels, Rate).GetHashCode();
    }
}
