using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange.EMail
{
    public class EMailTrackingInfo
    {
        public DateTime TimeStamp { get; set; }
        public Guid ID { get; set; }
        public string? Source { get; set; }
        public string? Agent { get; set; }
    }
}
