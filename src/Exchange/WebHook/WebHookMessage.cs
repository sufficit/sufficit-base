using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange.WebHook
{
    public class WebHookMessage : MessageExtended
    {
        [JsonConstructor]
        public WebHookMessage(Guid id) : base(id, TChannel.WEBHOOK) { }

        public WebHookMessage() : base(Guid.NewGuid(), TChannel.WEBHOOK) { }

        [JsonPropertyName("body")]
        public new object? Body { 
            get => JsonSerializer.Deserialize<JsonNode>(base.Body, Json.Options);
            set => base.Body = value?.ToString() != null ? Encoding.UTF8.GetBytes(value.ToString()!) : null; 
        }
    }
}
