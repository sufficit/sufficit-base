using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sufficit.Resources.TTS
{
    public class TTSResponse
    {
        public string FileName { get; set; } = default!;

        public string ContentType { get; set; } = default!;

        public uint Characters { get; set; }

        public Stream AudioStream { get; set; } = default!;
    }
}
