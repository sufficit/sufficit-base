using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit
{
    /// <summary>
    /// Specifies the type of schedule used in a cron expression.
    /// </summary>
    /// <remarks>This enumeration represents the different components of a cron schedule, such as minutes,
    /// hours,  days of the month, months, and weekdays. It can be used to define or interpret cron expressions  for
    /// scheduling tasks.</remarks>
    public enum CronScheduleType
    {
        MINUTES,
        HOURS,
        MONTHDAYS,
        MONTHS,
        WEEKDAYS
    }
}
