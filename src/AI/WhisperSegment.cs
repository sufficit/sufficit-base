using System.Text.Json.Serialization;

namespace Sufficit.AI
{
    /// <summary>
    /// Individual audio segment with detailed information
    /// Contains essential properties for segment identification and positioning
    /// </summary>
    public class WhisperSegment : WhisperSegmentBase
    {
        /// <summary>
        /// Segment ID
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Seek position in audio
        /// </summary>
        [JsonPropertyName("seek")]
        public int? Seek { get; set; }

        /// <summary>
        /// Language code for this segment
        /// </summary>
        [JsonPropertyName("language")]
        public string? Language { get; set; }

        /// <summary>
        /// Token IDs for this segment
        /// </summary>
        [JsonPropertyName("tokens")]
        public int[]? Tokens { get; set; }

        /// <summary>
        /// Temperature used for sampling
        /// </summary>
        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; }

        /// <summary>
        /// Average log probability
        /// </summary>
        [JsonPropertyName("avg_logprob")]
        public double? AvgLogprob { get; set; }

        /// <summary>
        /// Compression ratio
        /// </summary>
        [JsonPropertyName("compression_ratio")]
        public double? CompressionRatio { get; set; }

        /// <summary>
        /// No speech probability
        /// </summary>
        [JsonPropertyName("no_speech_prob")]
        public double? NoSpeechProb { get; set; }
    }
}