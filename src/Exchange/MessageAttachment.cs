using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange
{
    public class MessageAttachment
    {
        /// <summary>
        ///     Type of content
        /// </summary>
        [JsonPropertyName("mime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? MIME { get; set; }

        /// <summary>
        ///     Bytes file content
        /// </summary>
        [JsonPropertyName("content")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public byte[] Content { get; set; } = default!;

        /// <summary>
        ///     Sugestion for file name
        /// </summary>
        [JsonPropertyName("filename")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? FileName { get; set; }
    }
}
