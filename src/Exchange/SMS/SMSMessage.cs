using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange.SMS
{
    public class SMSMessage : MessageExtended
    {
        [JsonConstructor]
        public SMSMessage(Guid id) : base(id, TChannel.SMS) { }
    }
}
