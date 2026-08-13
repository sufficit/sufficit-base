using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sufficit.Tasks
{
    /// <summary>
    /// Persisted definition and mutable runtime state for one job schedule.
    /// Job discovery and execution belong to the Background runtime; this type
    /// intentionally contains no reflection or persistence behavior.
    /// </summary>
    public class ScheduleTask : CronSchedule
    {
        /// <summary>Stable schedule identifier.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid Id { get; set; }

        /// <summary>
        /// Runtime catalog key, normally the fully-qualified CLR type name with
        /// an optional assembly name.
        /// </summary>
        [Required, StringLength(512)]
        public string Method { get; set; } = default!;

        /// <summary>Optional JSON payload passed to the job.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public object? Args { get; set; }

        /// <summary>
        /// Optional comma- or semicolon-separated list of exact server names.
        /// Null or empty means that any runtime host may execute the schedule.
        /// </summary>
        [StringLength(250)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Servers { get; set; }

        /// <summary>Whether the scheduler may select this definition.</summary>
        public bool Active { get; set; }
            = true;

        /// <summary>Whether an execution lease is currently held.</summary>
        public bool Locked { get; set; }
            = false;

        /// <summary>
        /// UTC timestamp of the latest lease acquisition. While locked, this
        /// value acts as the lease fencing token used during owner release.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Timestamp { get; set; }
    }
}
