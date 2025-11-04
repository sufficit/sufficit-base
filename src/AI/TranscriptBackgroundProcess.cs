using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.AI
{
    /// <summary>
    /// Simple object to cache audio stream and background transcription processing status
    /// Combines audio data and status in a single cache entry for async transcript operations
    /// </summary>
    public class TranscriptBackgroundProcess
    {
        /// <summary>
        /// Complete Whisper transcription request
        /// </summary>
        public TranscriptBackgroundRequest Request { get; set; } = default!;

        /// <summary>
        /// Complete Whisper transcription response (populated when Status = Finished)
        /// </summary>
        public TranscriptResponse? Response { get; set; }

        /// <summary>
        /// Current processing status
        /// </summary>
        public WhisperProcessStatus Status { get; set; }

        /// <summary>
        /// Audio stream for background transcription (cached until completion)
        /// </summary>
        public Stream? AudioStream { get; set; }

        /// <summary>
        /// Error message (only populated when Status = Failed)
        /// </summary>
        public string? Error { get; set; }

        /// <summary>
        /// Task completion source for async waiting
        /// Created when process starts, completed when processing finishes
        /// </summary>
        [JsonIgnore]
        public TaskCompletionSource<TranscriptBackgroundProcess> Completion { get; } = new();
    }
}
