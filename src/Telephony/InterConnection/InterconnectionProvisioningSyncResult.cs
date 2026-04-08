using System;
using System.Collections.Generic;

namespace Sufficit.Telephony.InterConnection
{
    /// <summary>
    ///     Result of synchronizing one interconnection into the realtime PJSIP catalog.
    /// </summary>
    public class InterconnectionProvisioningSyncResult
    {
        public Guid InterconnectionId { get; set; }

        public string ObjectPrefix { get; set; } = string.Empty;

        public string ProvisioningStatus { get; set; } = string.Empty;

        public bool Applied { get; set; }

        public int EndPointCount { get; set; }

        public int AorCount { get; set; }

        public int AuthCount { get; set; }

        public int IdentifyCount { get; set; }

        public int RemovedEndPointCount { get; set; }

        public int RemovedAorCount { get; set; }

        public int RemovedAuthCount { get; set; }

        public int RemovedIdentifyCount { get; set; }

        public ICollection<string> Notes { get; set; } = new List<string>();
    }
}
