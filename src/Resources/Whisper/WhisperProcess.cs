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
        public Guid Id => Response.Id;

        public WhisperOptions Options { get; set; } = default!;

        [JsonIgnore]
        public MemoryStream Stream { get; set; } = default!;

        public WhisperResponse Response { get; set; } = default!;

        [JsonIgnore]
        public CancellationToken CancellationToken { get; set; }

        public Task? Task { get; set; }
    }
}
