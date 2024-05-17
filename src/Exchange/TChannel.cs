using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Exchange
{
    public enum TChannel
    {
        [EnumMember(Value = "unknown")]
        UNKNOWN = 0,

        [EnumMember(Value = "email")]
        EMAIL,

        [EnumMember(Value = "sms")]
        SMS,

        [EnumMember(Value = "internal")]
        INTERNAL,

        [EnumMember(Value = "whatsapp")]
        WHATSAPP,

        [EnumMember(Value = "telegram")]
        TELEGRAM,

        [EnumMember(Value = "push")]
        PUSH,

        [EnumMember(Value = "webhook")]
        WEBHOOK
    }
}
