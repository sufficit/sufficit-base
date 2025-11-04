namespace Sufficit.AI
{
    /// <summary>
    /// Configuration options for Whisper API
    /// OpenAI-compatible: Can be used with any API that follows OpenAI Whisper standard
    /// (e.g., official OpenAI API, local Whisper instances, or custom implementations)
    /// </summary>
    public class WhisperOptions
    {
        /// <summary>
        /// Configuration section path in appsettings.json
        /// </summary>
        public const string ConfigurationPath = "Sufficit:AI:Whisper";

        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Base URL for the Whisper API endpoint
        /// Default: https://whisper.sufficit.com.br (Sufficit's internal Whisper service)
        /// OpenAI: https://api.openai.com (requires OpenAI API key)
        /// Local: http://localhost:9000 (for local Whisper instances)
        /// </summary>
        public string BaseUrl { get; set; } = "https://whisper.sufficit.com.br";

        /// <summary>
        /// Authentication token (Bearer token)
        /// For Sufficit Whisper: Internal service token
        /// For OpenAI: Your OpenAI API key (sk-...)
        /// For local instances: May not be required (set to null)
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// Default Whisper model to use (optional)
        /// Examples: base, small, medium, large, large-v3, large-v3-turbo
        /// If null, the server will choose the default model
        /// </summary>
        public string? Model { get; set; }

        public int TimeoutSeconds { get; set; } = 300;
    }
}