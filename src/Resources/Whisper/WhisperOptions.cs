using System.Text.Json.Serialization;

namespace Sufficit.Resources.Whisper
{
    public class WhisperOptions
    {
        [JsonPropertyName("language")]
        public string Language { get; set; } = "pt";

        [JsonPropertyName("ggml")]
        public string GGML { get; set; } = "tiny";

        [JsonPropertyName("download")]
        public bool Download { get; set; } = false;

        [JsonPropertyName("threads")]
        public uint Threads { get; set; } = 4;
    }
}
