using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Audio
{
    public class WAVFileProperties
    {
        public TimeSpan TotalTime { get; set; }

        public ushort BitsPerSample { get; set; }
    }
}
