using System;
using System.Text.Json.Serialization;

namespace Sufficit.AI
{
    /// <summary>
    /// Base class for Whisper AI responses (transcription and translation)
    /// </summary>
    public abstract class WhisperResponse
    {
        /// <summary>
        /// Unique identifier for the request
        /// </summary>
        [JsonPropertyName("key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Key { get; set; }

        /// <summary>
        /// Audio duration in seconds
        /// </summary>
        [JsonPropertyName("duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public double? Duration { get; set; }

        /// <summary>
        /// Result text (transcribed or translated)
        /// </summary>
        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Text { get; set; }

        /// <summary>
        /// Whisper model used (e.g., "base", "large-v3-turbo")
        /// </summary>
        [JsonPropertyName("model")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Model { get; set; }

        /// <summary>
        /// Processing time in seconds
        /// </summary>
        [JsonPropertyName("processing_time")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public double? ProcessingTime { get; set; }

        /// <summary>
        /// Device used for processing (e.g., "cuda", "cpu")
        /// </summary>
        [JsonPropertyName("device")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Device { get; set; }

        /// <summary>
        /// Server that processed the request
        /// </summary>
        [JsonPropertyName("server")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Server { get; set; }

        /// <summary>
        /// Whether the response was served from cache
        /// </summary>
        [JsonPropertyName("cached")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Cached { get; set; }

        /// <summary>
        /// Audio segments with detailed information
        /// </summary>
        [JsonPropertyName("segments")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public WhisperSegment[]? Segments { get; set; }
    }
}