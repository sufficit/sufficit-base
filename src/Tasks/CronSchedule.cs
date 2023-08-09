using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sufficit.Tasks
{
    /// <summary>
    ///     Schedule like linux CRON tab
    /// </summary>
    public class CronSchedule
    {
        public string? Minutes { get; set; }

        public string? Hours { get; set; }

        public string? MonthDays { get; set; }

        public string? Months { get; set; }

        public string? WeekDays { get; set; }
    }
}
