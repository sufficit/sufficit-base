using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Web
{
    public class Recommendation
    {
        public LogLevel Severity { get; set; }

        public string? Title { get; set; }

        public string Message { get; set; } = default!;
    }
}
