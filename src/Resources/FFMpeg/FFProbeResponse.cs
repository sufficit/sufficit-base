using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.FFMpeg
{
    public class FFProbeResponse
    {
        [JsonPropertyName("streams")]
        public dynamic? Streams { get; set; }

        [JsonPropertyName("format")]
        public MediaFormat? Format { get; set; }
    }
}
