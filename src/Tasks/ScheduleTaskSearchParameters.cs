using System;
using System.Text.Json.Serialization;

namespace Sufficit.Tasks
{
    /// <summary>
    /// Filters persisted job schedules. When <see cref="ScheduledAtUtc"/> is
    /// supplied, the persistence query applies cron fields and last-run
    /// suppression for that UTC minute.
    /// </summary>
    public sealed class ScheduleTaskSearchParameters : ILimit
    {
        /// <summary>Optional schedule identifier.</summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? Id { get; set; }

        /// <summary>Optional active-state filter.</summary>
        [JsonPropertyName("active")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Active { get; set; }

        /// <summary>Optional lease-state filter.</summary>
        [JsonPropertyName("locked")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Locked { get; set; }

        /// <summary>
        /// UTC occurrence used to match cron fields. Local values are converted
        /// to UTC; unspecified values are interpreted as UTC.
        /// </summary>
        [JsonPropertyName("scheduledAtUtc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? ScheduledAtUtc { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public uint? Limit { get; set; }
    }
}
