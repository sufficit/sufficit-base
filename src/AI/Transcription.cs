using System;
using System.IO;
using System.Text.Json.Serialization;

namespace Sufficit.AI
{
    /// <summary>
    ///     Transcription operation containing request, response and error (if any)
    /// </summary>
    public class Transcription
    {        
        [JsonPropertyName("request")]
        public virtual TranscriptRequest Request { get; set; } = default!;

        [JsonPropertyName("response")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TranscriptResponse? Response { get; set; }

        [JsonPropertyName("exception")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Exception? Exception { get; set; }
    }
}