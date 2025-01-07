using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.TTS
{
    public abstract class TTSResponseMeta : Sufficit.IIndex
    {
        public const string HEADER_ID = "X-RESPONSE-ID";
        public const string HEADER_CHARACTERS = "X-RESPONSE-CHARS";

        /// <inheritdoc cref="TTSRequest.Id"/>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid Id { get; set; }

        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Url { get; set; }

        [JsonPropertyName("filename")]
        public string FileName { get; set; } = default!;

        [JsonPropertyName("contenttype")]
        public string ContentType { get; set; } = default!;

        [JsonPropertyName("characters")]
        public uint Characters { get; set; }
    }
}
