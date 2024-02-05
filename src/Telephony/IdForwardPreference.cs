using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    /// How the id should be forwarded at outbound calls
    /// </summary>
    public enum IdForwardPreference
    {
        /// <summary>
        ///  Use system default
        /// </summary>
        [EnumMember(Value = "Don't Care")]
        DontCare = 0,

        /// <summary>
        /// Default dial should forward identification
        /// </summary>
        [EnumMember(Value = "True")] 
        True = 1,

        /// <summary>
        /// Default dial should NOT forward identification
        /// </summary>
        [EnumMember(Value = "False")]
        False = 2,

        /// <summary>
        /// All dial methods should forward identification <br />
        /// This option, ignores alternatives dial methods  
        /// </summary>
        [EnumMember(Value = "Forced True")]
        ForcedTrue = 3,

        /// <summary>
        /// All dial methods should NOT forward identification <br />
        /// This option, ignores alternatives dial methods  
        /// </summary>
        [EnumMember(Value = "Forced False")]
        ForcedFalse = 4
    }
}
