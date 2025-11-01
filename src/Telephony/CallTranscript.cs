using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Sufficit.AI;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Call transcript record for telephony system
    /// Stores transcription results for phone calls from Asterisk PBX
    /// Focused on essential data for call transcription management
    /// </summary>
    public class CallTranscript
    {
        /// <summary>
        /// Unique identifier - Asterisk linkedid for the call
        /// Links transcription to the specific call in Asterisk CDR
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Whisper model used for transcription
        /// Allows clients to request more powerful models when needed
        /// Examples: "tiny", "base", "small", "medium", "large"
        /// </summary>
        [JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Transcribed text segments with timestamps
        /// Allows detection of long silence periods and precise timing
        /// </summary>
        [JsonPropertyName("segments")]
        public ICollection<WhisperSegmentBase>? Segments { get; set; }

        /// <summary>
        /// When the transcript was created/updated
        /// Single timestamp for audit trail
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// When the transcript expires (for cleanup)
        /// Prevents accumulation of old transcription data
        /// </summary>
        [JsonPropertyName("expiration")]
        public DateTimeOffset Expiration { get; set; }
    }
}