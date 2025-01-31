using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Audio
{
    public class AudioMixResponse : IIndex
    {
        /// <summary>
        ///     Unique identification for this request, used for caching
        /// </summary>
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

        [JsonIgnore]
        public byte[] Bytes { get; set; } = default!;
    }
}
