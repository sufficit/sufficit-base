using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.FFMpeg
{
    public class FFProbeResponse
    {
        [JsonPropertyName("format")]
        [JsonPropertyOrder(0)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public MediaFormat? Format { get; set; }

        [JsonPropertyName("streams")]
        [JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<StreamInfo> Streams { get; set; } = default!;
    }
}
