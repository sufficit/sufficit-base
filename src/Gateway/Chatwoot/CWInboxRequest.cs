using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.Chatwoot
{
    public class CWInboxRequest
    {
        [JsonPropertyName("identifier")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Identifier { get; set; }

        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }
    }
}
