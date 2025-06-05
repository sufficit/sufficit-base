using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Telephony.Call
{
    /// <summary>
    ///     General call disposition enumeration.
    /// </summary>
    public enum TelephonyCallDisposition
    {
        [EnumMember(Value = "unknown")]
        UNKNOWN = 0,

        [EnumMember(Value = "noanswer")]
        NOANSWER = 4,

        [EnumMember(Value = "answered")]
        ANSWERED = 6
    }
}
