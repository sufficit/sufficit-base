using System;
using System.Text.Json.Serialization;

namespace Sufficit.AI
{
    /// <summary>
    /// Response from transcription operation
    /// </summary>
    public class TranscriptResponse : WhisperResponse
    {
        /// <summary>
        /// Language code of the transcribed audio (e.g., "pt", "en")
        /// </summary>
        [JsonPropertyName("language")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Language { get; set; }
    }
}