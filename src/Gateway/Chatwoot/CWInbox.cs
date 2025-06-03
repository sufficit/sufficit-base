using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.Chatwoot
{
    /// <summary>
    ///     ChatWoot inbox information
    /// </summary>
    public class CWInbox
    {
        /// <summary>
        ///     Inbox identifier from Chatwoot
        /// </summary>
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; } = default!;
                
        [JsonPropertyName("type")]
        public CWInboxType Type { get; set; }

        /// <summary>
        ///     Customer identifier 
        /// </summary>
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }

        /// <summary>
        ///     Extension to place a call when a request is received
        /// </summary>
        [JsonPropertyName("destination")]
        public string? Destination { get; set; }

        [JsonPropertyName("idforward")]
        public bool IdForward { get; set; }
    }
}
