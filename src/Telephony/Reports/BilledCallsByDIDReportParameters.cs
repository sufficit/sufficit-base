using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Reports
{
    [Obsolete("Not used yet")]
    public class BilledCallsByDIDReportParameters
    {
        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }
    }
}
