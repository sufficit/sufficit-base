using System.Linq;

namespace Sufficit.Telephony.Call
{
    /// <summary>
    /// Extension methods for CallTranscript class
    /// </summary>
    public static class TelephonyCallTranscriptExtensions
    {
        /// <summary>
        /// Gets the unified text from all transcript segments
        /// Combines all segment texts into a single continuous text
        /// </summary>
        /// <param name="transcript">The call transcript</param>
        /// <returns>Unified text from all segments, or empty string if no segments</returns>
        public static string GetText(this TelephonyCallTranscript transcript)
        {
            if (transcript?.Segments == null || !transcript.Segments.Any())
                return string.Empty;

            return string.Join(" ", transcript.Segments
                .Where(s => !string.IsNullOrWhiteSpace(s.Text))
                .Select(s => s.Text!.Trim())
                .Where(text => !string.IsNullOrEmpty(text)));
        }
    }
}