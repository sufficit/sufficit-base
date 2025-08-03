using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Text.Json.Nodes;

namespace Sufficit
{
    public class HealthResponse
    {
        public string Status { get; set; } = string.Empty;

        public TimeSpan TotalDuration { get; set; }

        public JsonNode Entries { get; set; } = default!;
    }
}
