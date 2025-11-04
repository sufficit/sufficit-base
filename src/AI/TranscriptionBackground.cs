using System;
using System.IO;
using System.Text.Json.Serialization;

namespace Sufficit.AI
{
    /// <summary>
    ///     Transcription operation containing request, response and error (if any)
    /// </summary>
    public class TranscriptionBackground : Transcription
    {
        public new TranscriptBackgroundRequest Request { get => (TranscriptBackgroundRequest)base.Request; set => base.Request = value; }

        /// <summary>
        /// Current processing status
        /// </summary>
        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WhisperProcessStatus Status { get; set; }
    }
}