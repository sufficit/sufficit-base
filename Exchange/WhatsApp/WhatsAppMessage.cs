using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange.WhatsApp
{
    public class WhatsAppMessage : Message
    {
        public WhatsAppMessage(Guid id) : base(id, TChannel.WHATSAPP) { }

        public WhatsAppAttachment Attachment { get; set; }
    }

    public class WhatsAppAttachment : MessageAttachment
    {
        public long Length { get; set; }
        public string FileName { get; set; }
        public string Base64 { get
            {
                if (Body != null)
                    return Convert.ToBase64String(Body);
                return string.Empty;
            }
            set
            {
                Body = Convert.FromBase64String(value);
            }
        }
    }
}
