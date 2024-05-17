using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange.WhatsApp
{
    public class WhatsAppMessage : MessageExtended
    {
        [JsonConstructor]
        public WhatsAppMessage(Guid id) : base(id, TChannel.WHATSAPP) { }

        public WhatsAppAttachment? Attachment { get; set; }
    }
}
