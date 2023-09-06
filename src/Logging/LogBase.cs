using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Logging
{
    public abstract class LogBase
    {
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }

        public Guid ContextId { get; set; }

        [StringLength(150)]
        public string ClassName { get; set; } = default!;

        /// <summary>
        ///     Key for object reference, external id
        /// </summary>
        [StringLength(50)]
        [DefaultValue("")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Reference { get; set; } = string.Empty;

        public DateTime Expiration { get; set; }        

        [StringLength(200)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual TimeSpan? Duration { get; set; }

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
