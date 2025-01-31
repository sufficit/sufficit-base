using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sufficit.Audio
{
    public class MediaStream : MemoryStream
    {
        public MediaStream() { }

        public MediaStream(byte[] buffer) : base (buffer) { }

        public string? ContentType { get; set; }
    }
}
