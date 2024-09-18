using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Resources.Whisper
{
    public class WhisperResponse : IKey
    {
        string IKey.Key => Id;

        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Id { get; set; } = default!;

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
