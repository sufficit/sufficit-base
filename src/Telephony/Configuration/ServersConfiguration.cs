using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Configuration
{
    public class ServersConfiguration
    {
        public const string SECTIONNAME = "Sufficit:Telephony:Servers";

        public ServerOptions FreePBXWeb { get; set; }
    }
}
