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
        /// <summary>
        ///     Between 00 and 59
        /// </summary>
        public string? Minutes { get; set; }

        /// <summary>
        ///     Between 00 and 23
        /// </summary>
        public string? Hours { get; set; }

        /// <summary>
        ///     Between 01 and 31
        /// </summary>
        public string? MonthDays { get; set; }

        /// <summary>
        ///     Between 01 and 12
        /// </summary>
        public string? Months { get; set; }

        /// <summary>
        ///     Between 00 and 06
        /// </summary>
        public string? WeekDays { get; set; }
    }
}
