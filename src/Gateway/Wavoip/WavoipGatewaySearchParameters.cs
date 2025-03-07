using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.Wavoip
{
    public class WavoipGatewaySearchParameters
    {
        [JsonPropertyName("contextid")]
        public Guid? ContextId { get; set; }

        [JsonPropertyName("title")]
        public TextFilter? Title { get; set; }
    }
}
