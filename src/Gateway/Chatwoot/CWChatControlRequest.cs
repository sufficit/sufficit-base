using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.Chatwoot
{
    public class CWChatControlRequest
    {
        public CWChatControlRequest()
        {
            Payload = new CWChatControlRequestPayload();
            Contact = new CWChatControlRequestContact();
        }

        [JsonPropertyName("payload")]
        public CWChatControlRequestPayload Payload { get; set; }

        [JsonPropertyName("contact")]
        public CWChatControlRequestContact Contact { get; set; }
    }

    public class CWChatControlRequestPayload
    {
        [JsonPropertyName("content")]
        public string Content { get; set; } = default!;
    }

    public class CWChatControlRequestContact
    {
        public CWChatControlRequestContact()
        {
            Attributes = new CWChatControlRequestContactAttributes();
        }

        [JsonPropertyName("attributes")]
        public CWChatControlRequestContactAttributes Attributes { get; set; }
    }

    public class CWChatControlRequestContactAttributes
    {
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }
    }    
}
