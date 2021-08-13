using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Reports
{
    public class ReportProgress : IReportProgress
    {
        public uint Percentage { get; set; }

        public string Status { get; set; }

        public ReportStepEnum Step { get; set; }


        public static implicit operator uint (ReportProgress source)
        {
            return source?.Percentage ?? 0;
        }

        public static implicit operator string(ReportProgress source)
        {
            return source?.Status ?? string.Empty;
        }

        public static implicit operator ReportStepEnum(ReportProgress source)
        {
            return source?.Step ?? ReportStepEnum.UNKNOWN;
        }
    }
}
