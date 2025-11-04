using System;

namespace Sufficit.AI
{
    /// <summary>
    /// Event published when a background transcript is completed successfully
    /// </summary>
    public class TranscriptCompletedEvent
    {
        /// <summary>
        /// Unique key for the transcript request
        /// </summary>
        public string Key { get; set; } = default!;

        /// <summary>
        /// Original transcript request
        /// </summary>
        public TranscriptBackgroundRequest Request { get; set; } = default!;

        /// <summary>
        /// Transcript response with segments and metadata
        /// </summary>
        public TranscriptResponse Response { get; set; } = default!;

        /// <summary>
        /// When the transcription was completed
        /// </summary>
        public DateTimeOffset CompletedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
