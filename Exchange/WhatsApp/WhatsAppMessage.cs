using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange.WhatsApp
{
    public class WhatsAppMessage : Message
    {
        public WhatsAppMessage(Guid id) : base(id, TChannel.TELEGRAM) { }
    }
}
