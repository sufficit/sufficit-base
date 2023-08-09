using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Tasks
{
    public class ScheduleTask : CronSchedule
    {
        public Guid Id { get; set; }

        public string Method { get; set; } = default!;

        public object? Args { get; set; }

        public bool Active { get; set; }

        public bool Locked { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
