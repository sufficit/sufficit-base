using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.OpenAI.Files
{
    /// <summary>
    ///     OpenAI File List Response
    ///     https://platform.openai.com/docs/api-reference/files/list
    /// </summary>
    public class OpenAIFileListResponse
    {
        /// <summary>
        ///     The object type, which is always "list".
        /// </summary>
        [JsonPropertyName("object")]
        public string Object { get; set; } = "list";

        /// <summary>
        ///     List of file objects.
        /// </summary>
        [JsonPropertyName("data")]
        public List<OpenAIFileObject> Data { get; set; } = new();
    }
}
