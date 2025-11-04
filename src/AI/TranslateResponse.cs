using System.Text.Json.Serialization;

namespace Sufficit.AI
{
    /// <summary>
    /// Response from translation operation
    /// </summary>
    public class TranslateResponse : WhisperResponse
    {
        /// <summary>
        /// Detected source language code (e.g., "pt", "es")
        /// </summary>
        [JsonPropertyName("detected_language")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? DetectedLanguage { get; set; }
    }
}