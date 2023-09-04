using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.FreePBX
{
    public class FreePBXEPProperty
    {
        public string id { get; set; } = "-1";
        public string keyword { get; set; } = string.Empty;
        public string data { get; set; } = string.Empty;
        public int flags { get; set; }
    }
}
