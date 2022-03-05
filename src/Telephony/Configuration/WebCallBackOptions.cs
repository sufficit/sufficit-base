using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Configuration
{
    public class WebCallBackOptions
    {
        public WebCallBackOptions() { BlackList = new HashSet<string>(); }
        public ICollection<string> BlackList { get; }
    }
}
