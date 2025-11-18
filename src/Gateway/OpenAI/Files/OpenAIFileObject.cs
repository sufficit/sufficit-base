using System.Text.Json.Serialization;

namespace Sufficit.Gateway.OpenAI.Files
{
    /// <summary>
    ///     OpenAI File Object
    ///     https://platform.openai.com/docs/api-reference/files/object
    /// </summary>
    public class OpenAIFileObject
    {
        /// <summary>
        ///     The file identifier, which can be referenced in the API endpoints.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = default!;

        /// <summary>
        ///     The object type, which is always "file".
        /// </summary>
        [JsonPropertyName("object")]
        public string Object { get; set; } = "file";

        /// <summary>
        ///     The size of the file in bytes.
        /// </summary>
        [JsonPropertyName("bytes")]
        public long Bytes { get; set; }

        /// <summary>
        ///     The Unix timestamp (in seconds) for when the file was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }

        /// <summary>
        ///     The name of the file.
        /// </summary>
        [JsonPropertyName("filename")]
        public string Filename { get; set; } = default!;

        /// <summary>
        ///     The intended purpose of the file. 
        ///     Supported values are "assistants", "fine-tune", "batch", "vision".
        /// </summary>
        [JsonPropertyName("purpose")]
        public string Purpose { get; set; } = default!;

        /// <summary>
        ///     Deprecated. The current status of the file, which can be either "uploaded", "processed", or "error".
        /// </summary>
        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Status { get; set; }

        /// <summary>
        ///     Deprecated. Additional details about the status of the file.
        /// </summary>
        [JsonPropertyName("status_details")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? StatusDetails { get; set; }
    }
}
