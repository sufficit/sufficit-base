using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Asterisk.RealTime
{
    public class RealTimeConfigSearchParameters : SearchParameters
    {
        public TextFilter? VarName { get; set; }

        public TextFilter? VarValue { get; set; }
    }
}
