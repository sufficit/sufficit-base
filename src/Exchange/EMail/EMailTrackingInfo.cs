using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange.EMail
{
    /// <summary>
    /// Basic information about open and reading emails sended by this system <br/>
    /// Common used with an jpg image tracking
    /// </summary>
    public class EMailTrackingInfo
    {
        public DateTime TimeStamp { get; set; }
        public Guid ID { get; set; }
        public string? Source { get; set; }
        public string? Agent { get; set; }

        public override bool Equals(object obj)
            => obj is EMailTrackingInfo p && p.TimeStamp == TimeStamp && p.ID== ID && p.Source== Source && p.Agent== Agent;

        public override int GetHashCode()
            => (TimeStamp, ID, Source, Agent).GetHashCode();
    }
}
