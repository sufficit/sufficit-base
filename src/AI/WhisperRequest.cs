using System;
using System.IO;
using System.Text.Json.Serialization;

namespace Sufficit.AI
{
    /// <summary>
    /// Request for audio transcription or translation
    /// </summary>
    public class WhisperRequest
    {
        /// <summary>
        /// Audio stream to transcribe
        /// </summary>
        [JsonIgnore]
        public Stream AudioStream { get; set; } = default!;

        /// <summary>
        /// Original filename for validation purposes
        /// </summary>
        [JsonPropertyName("filename")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? FileName { get; set; }

        /// <summary>
        /// Whisper model to use (optional, server decides default)
        /// </summary>
        [JsonPropertyName("model")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Model { get; set; }

        /// <summary>
        /// Optional prompt to guide transcription
        /// </summary>
        [JsonPropertyName("prompt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Prompt { get; set; }

        /// <summary>
        /// Response format: json (default), text, srt, verbose_json, vtt
        /// </summary>
        [JsonPropertyName("response_format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? ResponseFormat { get; set; } = "verbose_json";

        /// <summary>
        /// Sampling temperature (0 to 1, null = default)
        /// </summary>
        [JsonPropertyName("temperature")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public double? Temperature { get; set; }
    }
}