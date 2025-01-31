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
        public new virtual object? Body { get; set; }
    }
}
