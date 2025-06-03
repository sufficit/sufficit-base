using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Notification
{
    public enum SubscribeMethod
    {
        // system events with no subscribe method
        [EnumMember(Value = "none")]
        None = -1,

        [EnumMember(Value = "key")]
        ByKey = 0,

        [EnumMember(Value = "context")]
        ByContextId,

        [EnumMember(Value = "both")]
        ByKeyAndContextId,
    }
}
