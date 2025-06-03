using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Resources.Whisper
{
    public class WhisperResponse : IKey
    {
        /// <inheritdoc cref="IKey.Key" />
        [JsonPropertyOrder(0)]
        [JsonPropertyName("key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Key { get; set; } = default!;

        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        [Obsolete("Use Key instead. This will be removed in a future version.")]
        public string Id { get => Key; set => Key = value; }

        [JsonPropertyOrder(1)]
        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WhisperProcessStatus Status { get; set; }

        [JsonPropertyOrder(2)]
        [JsonPropertyName("exception")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Exception { get; set; }

        [JsonPropertyOrder(3)]
        [JsonPropertyName("statistics")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public WhisperStatistics Statistics { get; set; }
            = new WhisperStatistics();

        [JsonPropertyOrder(4)]
        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Text 
            => (Segments != null && Segments.Count > 0) ? string.Concat(Segments.OrderBy(s => s.Start).Select(s => s.Text)).TrimStart() : null;

        [JsonPropertyOrder(5)]
        [JsonPropertyName("segments")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HashSet<WhisperSegment>? Segments { get; set; }
    }
}
