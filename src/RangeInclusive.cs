using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit
{
    /// <summary>
    ///     Explains the inclusivity of a range in a query or operation   
    /// </summary>
    public enum RangeInclusive
    {
        /// <summary>
        ///     No inclusivity, both ends are exclusive
        /// </summary>
        [EnumMember(Value = "none")]
        NONE = 0,

        /// <summary>
        ///     Both ends are inclusive
        /// </summary>
        [EnumMember(Value = "both")]
        BOTH = 1,

        /// <summary>
        ///     Only the start is inclusive, the end is exclusive
        /// </summary>
        [EnumMember(Value = "start")]
        START,

        /// <summary>
        ///     Only the end is inclusive, the start is exclusive
        /// </summary>
        [EnumMember(Value = "end")]
        END,     
    }
}
