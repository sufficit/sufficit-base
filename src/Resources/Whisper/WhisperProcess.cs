using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Resources.Whisper
{
    public class WhisperProcess
    {
        public string Id => Response.Id;

        public WhisperOptions Options { get; set; } = default!;

        [JsonIgnore]
        public MemoryStream Stream { get; set; } = default!;

        public WhisperResponse Response { get; set; } = default!;

        [JsonIgnore]
        public CancellationTokenSource CancellationTokenSource { get; set; } = default!;

        public Task? Task { get; set; }
    }
}
