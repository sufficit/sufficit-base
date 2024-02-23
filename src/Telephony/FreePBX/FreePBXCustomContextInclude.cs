using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.FreePBX
{
    public class FreePBXCustomContextInclude
    {
        public string context { get; set; } = default!;
        public string include { get; set; } = default!;
        public int? timegroupid { get; set; } 
        public int sort { get; set; }
        public string? userules { get; set; }
    }
}
