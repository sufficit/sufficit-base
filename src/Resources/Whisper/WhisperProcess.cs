using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Resources.Whisper
{
    public class WhisperProcess : IKey
    {
        /// <inheritdoc cref="IKey.Key" />
        [JsonPropertyOrder(0)]
        [JsonPropertyName("key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Key { get; set; } = default!;

        public WhisperOptions Options { get; set; } = default!;

        [JsonIgnore]
        public MemoryStream Stream { get; set; } = default!;

        public WhisperResponse Response { get; set; } = default!;

        [JsonIgnore]
        public CancellationTokenSource CancellationTokenSource { get; set; } = default!;

        [JsonIgnore]
        public Task? Task { get; set; }
    }
}
