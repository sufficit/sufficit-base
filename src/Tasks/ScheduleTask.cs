using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Tasks
{
    public class ScheduleTask : CronSchedule
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid Id { get; set; }

        [JsonRequired]
        public string Method { get; set; } = default!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public object? Args { get; set; }

        public bool Active { get; set; }
            = true;

        public bool Locked { get; set; }
            = false;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Timestamp { get; set; }
    }
}
