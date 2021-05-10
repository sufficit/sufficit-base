using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange.SMS
{
    public class SMSMessage : Message
    {
        public SMSMessage(): base(Guid.NewGuid(), TChannel.SMS) { }

        public SMSMessage(Guid id) : base(id, TChannel.SMS) { }
    }
}
