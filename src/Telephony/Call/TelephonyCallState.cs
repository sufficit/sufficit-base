using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Telephony.Call
{
    /// <summary>
    ///     Interface for telephony call state enumeration. 
    ///     Indicates the current state of a telephony call.
    /// </summary>
    public enum TelephonyCallState
    {
        /// <summary>
        ///     Initial or End state, before dialing or after hangup.
        /// </summary>
        [EnumMember(Value = "down")]
        DOWN,

        /// <summary>
        ///     Dialing state, when the system is attempting to connect the call.
        /// </summary>
        [EnumMember(Value = "dialing")]
        DIALING,

        /// <summary>
        ///     Ringing state, when the call is being signaled to the recipient.
        /// </summary>
        [EnumMember(Value = "ringing")]
        RINGING,

        /// <summary>
        ///     Call is currently active and connected.
        /// </summary>
        [EnumMember(Value = "up")]
        UP,

        /// <summary>
        ///     Call is currently on busy state, meaning the line is engaged or occupied.
        /// </summary>
        [EnumMember(Value = "busy")]
        BUSY,
    }
}
