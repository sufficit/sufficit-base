using System.Text.Json.Serialization;

namespace Sufficit.Gateway.OpenAI.Files
{
    /// <summary>
    ///     OpenAI File Delete Response
    ///     https://platform.openai.com/docs/api-reference/files/delete
    /// </summary>
    public class OpenAIFileDeleteResponse
    {
        /// <summary>
        ///     The file identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = default!;

        /// <summary>
        ///     The object type, which is always "file".
        /// </summary>
        [JsonPropertyName("object")]
        public string Object { get; set; } = "file";

        /// <summary>
        ///     Whether the file was successfully deleted.
        /// </summary>
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }
    }
}
