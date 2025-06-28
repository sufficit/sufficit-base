using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Identity
{
    public class PersistedGrantSearchParameters
    {
        public Guid? SubjectId { get; set; }

        public string? ClientId { get; set; }

        public string? Type { get; set; }

        public DateTimeRangeNew? Expiration { get; set; }
    }
}
