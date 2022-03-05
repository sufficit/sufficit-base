using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Configuration
{
    public class ServerOptions
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public uint Port { get; set; }
    }
}
