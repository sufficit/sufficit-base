using Sufficit.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Reports
{
    public class BilledCallsByDIDReport : ReportBase<BilledCallsByDIDReportItem, ReportParametersNew>
    {
        public BilledCallsByDIDReport() { }

        public BilledCallsByDIDReport (ReportParametersNew parameters)
        {
            Parameters = parameters;
        }
    }
}
