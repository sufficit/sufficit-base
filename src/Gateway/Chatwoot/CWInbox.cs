using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.Chatwoot
{
    /// <summary>
    /// Chawoot inbox information
    /// </summary>
    public class CWInbox
    {
        /// <summary>
        /// Inbox identifier from Chatwoot
        /// </summary>
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; } = default!;

        /// <summary>
        /// Client identifier 
        /// </summary>
        [JsonPropertyName("contextId")]
        public Guid? ContextId { get; set; }

        /// <summary>
        /// Extension to place a call when a request is received
        /// </summary>
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = default!;
    }
}
