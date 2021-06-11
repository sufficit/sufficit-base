using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange
{
    public class OrphanEventMessage : Message
    {
        public OrphanEventMessage(string recipient, string emitter, Guid id = default):base(id, TChannel.INTERNAL)
        {
            this.Recipient = recipient;
            this.Emitter = emitter;
        }
    }
}
