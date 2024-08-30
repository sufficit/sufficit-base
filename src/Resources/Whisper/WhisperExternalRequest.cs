using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.Whisper
{
    public class WhisperExternalRequest : WhisperRequest
    {
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Url { get; set; }

        [JsonIgnore]
        public Stream? Stream { get; set; }
    }
}
