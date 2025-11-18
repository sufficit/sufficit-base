namespace Sufficit.Gateway.OpenAI
{
    /// <summary>
    /// OpenAI-compatible transcription/translation response
    /// </summary>
    public class OpenAITranscriptionResponse
    {

        public string Text { get; set; } = string.Empty;

        public string? Language { get; set; }

        public double? Duration { get; set; }

        public OpenAISegment[]? Segments { get; set; }

    }
}
