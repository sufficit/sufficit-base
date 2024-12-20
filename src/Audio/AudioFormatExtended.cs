using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Audio
{
    public class AudioFormatExtended : AudioFormat
    {
        [JsonPropertyName("duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double Duration { get; set; }

        [JsonPropertyName("codec")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Codec { get; set; } = default!;

        public override bool Equals(object? obj)
            => obj is AudioFormatExtended other && other.Duration == Duration && other.Codec == Codec && base.Equals(other);

        public override int GetHashCode()
            => (Duration, Codec, base.GetHashCode()).GetHashCode();
    }
}
