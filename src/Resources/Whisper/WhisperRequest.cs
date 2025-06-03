using System;
using System.IO;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.Whisper
{
    public class WhisperRequest : WhisperOptions
    {
        /// <summary>
        ///     Optional key to identify the request. it is necessary for cache and response tracking.
        /// </summary>
        [JsonPropertyOrder(0)]
        [JsonPropertyName("key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string? Key { get; set; }

        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        [Obsolete("Use Key instead. This will be removed in a future version.")]
        public string? Id { get => Key; set => Key = value; }

        [JsonPropertyOrder(1)]
        [JsonPropertyName("await")]
        public bool Await { get; set; } = true;

        /// <summary>
        ///     Override cache and force a new process.
        /// </summary>
        [JsonPropertyOrder(2)]
        [JsonPropertyName("force")]
        public bool Force { get; set; } = false;
    }
}
