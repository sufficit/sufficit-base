using System;
using System.IO;
using System.Text.Json.Serialization;

namespace Sufficit.AI
{
    /// <summary>
    /// Request for background audio transcription/translation processing
    /// Extends TranscriptRequest with async processing capabilities
    /// </summary>
    public class TranscriptBackgroundRequest : TranscriptRequest
    {
        /// <summary>
        /// Unique key to identify the cached transcription request
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; } = default!;

        /// <summary>
        /// If true, the request will wait for the transcription to complete before returning
        /// </summary>
        [JsonPropertyName("await")]
        public bool Await { get; set; } = false;
        
        /// <summary>
        ///     When the transcription status was created
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
    }
}