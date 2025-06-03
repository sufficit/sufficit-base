using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Gateway.Chatwoot
{
    public enum CWInboxType
    {
        [EnumMember(Value = "message")]
        Message,

        [EnumMember(Value = "voip")]
        VoIP
    }
}
