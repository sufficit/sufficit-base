using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.TTS
{
    public class TTSResponse : TTSResponseMeta
    {
        [JsonIgnore]
        public byte[] Audio { get; set; } = default!;
    }
}
