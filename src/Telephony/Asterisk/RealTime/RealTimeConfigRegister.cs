using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Asterisk.RealTime
{
    public class RealTimeConfigRegister : RealTimeConfig
    {
        public override string Category => string.Empty;
        public override string Filename => "sip_registrations_custom.conf";
        public override string VarName => "register";
    }
}
