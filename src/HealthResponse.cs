using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Sufficit
{
    public class HealthResponse
    {
        public string Status { get; set; } = string.Empty;

        public TimeSpan TotalDuration { get; set; }

        public ExpandoObject? Entries { get; set; }
    }
}
