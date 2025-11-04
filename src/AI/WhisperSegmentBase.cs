using System.Text.Json.Serialization;

namespace Sufficit.AI
{
    /// <summary>
    /// Base class for audio transcription segments
    /// Contains essential properties for segment identification and positioning
    /// </summary>
    public class WhisperSegmentBase
    {
        /// <summary>
        /// Start time of the segment in seconds
        /// </summary>
        [JsonPropertyName("start")]
        public double? Start { get; set; }

        /// <summary>
        /// End time of the segment in seconds
        /// </summary>
        [JsonPropertyName("end")]
        public double? End { get; set; }

        /// <summary>
        /// Transcribed text for this segment
        /// </summary>
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}