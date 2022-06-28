using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Logging
{
    public class LogBase
    {
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }

        public Guid ContextId { get; set; }

        [StringLength(200)]
        public string ClassName { get; set; } = default!;

        public DateTime Expiration { get; set; }

        public Guid ReferenceId { get; set; }

        [StringLength(200)]
        public string? Message { get; set; }

        public virtual object? Content { get; set; }

        public TimeSpan? Duration { get; set; }

        [StringLength(100)]
        public string? Server { get; set; }

        public Guid UserId { get; set; }
    }
}
