using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Events
{
    /// <summary>
    /// Payload published to RabbitMQ after a successful voicemail capture.
    /// This contract is shared between the voicemail producer and consumers.
    /// </summary>
    public sealed class VoiceMailCapturedPayload
    {
        /// <summary>
        /// Identifier of the voicemail box that received the recording.
        /// </summary>
        [JsonPropertyName("box_id")]
        public Guid BoxId { get; set; }

        /// <summary>
        /// Caller identifier captured from the channel, when available.
        /// </summary>
        [JsonPropertyName("caller_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CallerId { get; set; }

        /// <summary>
        /// UTC timestamp indicating when the recording was captured.
        /// </summary>
        [JsonPropertyName("recorded_at_utc")]
        public DateTime RecordedAtUtc { get; set; }

        /// <summary>
        /// Recording duration in seconds.
        /// </summary>
        [JsonPropertyName("duration_seconds")]
        public double DurationSeconds { get; set; }

        /// <summary>
        /// Audio codec/format used to store the captured media (for example: wav, gsm, ulaw).
        /// </summary>
        [JsonPropertyName("audio_format")]
        public string AudioFormat { get; set; } = string.Empty;

        /// <summary>
        /// Base64 representation of the audio binary content.
        /// </summary>
        [JsonPropertyName("audio_body")]
        public string AudioBody { get; set; } = string.Empty;
    }
}