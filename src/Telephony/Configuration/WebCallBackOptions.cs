using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Configuration
{
    public class WebCallBackOptions
    {
        public WebCallBackOptions() { BlackList = new HashSet<string>(); }
        public HashSet<string> BlackList { get; }

        public override bool Equals(object other) =>
          other is WebCallBackOptions p && (p.BlackList).Equals((BlackList));

        public override int GetHashCode() => (BlackList).GetHashCode();
    }
}
