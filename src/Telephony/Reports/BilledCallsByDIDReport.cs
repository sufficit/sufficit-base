using Sufficit.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Reports
{
    public class BilledCallsByDIDReport : ReportBaseGeneric<BilledCallsByDIDReportItem, ReportParametersNew>
    {
        public override Guid ModelId => new Guid("C0D3F1A2-4E5B-4F6A-8E7C-9B2D3E5F1A2B");
    }
}
