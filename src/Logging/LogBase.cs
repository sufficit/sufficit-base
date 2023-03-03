using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Logging
{
    public class LogBase
    {
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }

        public Guid ContextId { get; set; }

        [StringLength(150)]
        public string ClassName { get; set; } = default!;

        public DateTime Expiration { get; set; }

        /// <summary>
        /// Key for object reference, external id
        /// </summary>
        [StringLength(50)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Reference { get; set; }

        [StringLength(200)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Message { get; set; }

        [JsonIgnore]
        public virtual object? Content { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Title for the server that processed this event
        /// </summary>
        /// <value>Environment.MachineName</value>
        [StringLength(100)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Server { get; set; } = Environment.MachineName;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? UserId { get; set; }
    }
}
