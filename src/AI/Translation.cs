using System;
using System.IO;
using System.Text.Json.Serialization;

namespace Sufficit.AI
{
    /// <summary>
    ///     Translation operation containing request, response and error (if any)
    /// </summary>
    public class Translation
    {        
        [JsonPropertyName("request")]
        public WhisperRequest Request { get; set; } = default!;

        [JsonPropertyName("response")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TranslateResponse? Response { get; set; }

        [JsonPropertyName("exception")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Exception? Exception { get; set; }
    }
}