using System;
using System.IO;
using System.Text.Json.Serialization;

namespace Sufficit.AI
{
    /// <summary>
    /// Enhanced request for audio transcription or translation with advanced Whisper parameters
    /// Extends WhisperRequest with additional parameters supported by faster-whisper
    /// </summary>
    public class WhisperRequestEnhanced : WhisperRequest
    {
        /// <summary>
        /// Threshold for considering a segment as silence (0.0 to 1.0, null = default)
        /// Lower values detect more silence, higher values require louder audio
        /// </summary>
        [JsonPropertyName("no_speech_threshold")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public double? NoSpeechThreshold { get; set; }

        /// <summary>
        /// Threshold for compression ratio filtering (> 2.0, null = default)
        /// Higher values filter out repetitive or low-information content more aggressively
        /// </summary>
        [JsonPropertyName("compression_ratio_threshold")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public double? CompressionRatioThreshold { get; set; }

        /// <summary>
        /// Penalty for repetitive content (> 1.0, null = default)
        /// Higher values discourage repetition in the output
        /// </summary>
        [JsonPropertyName("repetition_penalty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public double? RepetitionPenalty { get; set; }

        /// <summary>
        /// Number of beams for beam search decoding (1-10, null = default)
        /// Higher values may improve accuracy but increase processing time
        /// </summary>
        [JsonPropertyName("beam_size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public int? BeamSize { get; set; }
    }
}