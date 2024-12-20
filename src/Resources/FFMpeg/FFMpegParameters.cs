using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Resources.FFMpeg
{
    public class FFMpegParameters
    {
        public string[]? Options { get; set; }

        public string[] InFiles { get; set; } = default!;

        public string[]? InFileOptions { get; set; }

        public string OutFile { get; set; } = default!;

        public string[]? OutFileOptions { get; set; }
    }
}
