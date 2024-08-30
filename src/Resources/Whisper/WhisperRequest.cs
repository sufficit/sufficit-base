using System;
using System.IO;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.Whisper
{
    public class WhisperRequest : WhisperOptions
    {
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public Guid? Id { get; set; }

        [JsonPropertyOrder(1)]
        [JsonPropertyName("await")]
        public bool Await { get; set; } = true;
    }
}
