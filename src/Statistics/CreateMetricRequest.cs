using System;
using System.Collections.Generic;

namespace Sufficit.Statistics
{
    public class CreateMetricRequest
    {
        public string Measurement { get; set; } = string.Empty;

        public Dictionary<string, string>? Tags { get; set; }

        public Dictionary<string, object>? Fields { get; set; }

        public DateTime? Timestamp { get; set; }
    }
}
