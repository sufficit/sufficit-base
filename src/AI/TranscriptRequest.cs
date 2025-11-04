using System;
using System.IO;
using System.Text.Json.Serialization;

namespace Sufficit.AI
{
    /// <summary>
    /// Request for audio transcription
    /// </summary>
    public class TranscriptRequest : WhisperRequestEnhanced
    {
        /// <summary>
        /// Target language for transcription
        /// </summary>
        [JsonPropertyName("language")]        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Language { get; set; }
    }
}