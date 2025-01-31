using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Audio
{
    public class BackgroundAudioExtended
    {
        [JsonPropertyName("meta")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public BackgroundAudio Meta { get; set; } = default!;

        [JsonPropertyName("bytes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public byte[] Bytes { get; set; } = default!;
    }
}
