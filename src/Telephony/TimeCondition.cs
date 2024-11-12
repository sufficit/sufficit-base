using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public class TimeCondition
    {
        public const string FREEPBXCONTEXT = "sufficit-app-timecondition";
        public const string FRIENDLYNAME = "Horário";

        public HashSet<TimeInterval> Intervals { get; set; } 
            = new HashSet<TimeInterval>();



    }
}
