using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.FreePBX
{
    public class FreePBXDevice
    {
        public string id { get; set; } = string.Empty;
        public string tech { get; set; } = string.Empty;
        public string dial { get; set; } = string.Empty;
        public string devicetype { get; set; } = string.Empty;
        public string? user { get; set; }
        public string? description { get; set; }
        public string? emergency_cid { get; set; }
        public string? hint_override { get; set; }
    }
}
