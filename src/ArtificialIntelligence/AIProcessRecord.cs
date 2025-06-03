using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.ArtificialIntelligence
{
    public class AIProcessRecord : AIProcess
    {
        [JsonPropertyName("expiration")]
        public DateTimeOffset Expiration { get; set; }
    }
}
