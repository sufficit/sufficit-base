using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public enum DialOutTrunkType
    {
        UNKNOWN = 0,

        /// <summary>
        ///     Billed by time, with identification
        /// </summary>
        BILLED = 1,

        /// <summary>
        ///     Unlimited mobile calls without identification
        /// </summary>
        MOBILE = 2,

        /// <summary>
        ///     Unlimited fixed calls without identification
        /// </summary>
        FIXED = 3,

        /// <summary>
        ///     Mobile or Fixed calls, limit at 150 by day (measured by 3 days), without identification
        /// </summary>
        FLEX = 4,

        /// <summary>
        ///     Mobile or Fixed calls, limit at 10 by day, without identification
        /// </summary>
        FREE = 5,

        /// <summary>
        ///     Mobile or Fixed calls, limit at 30 by day, with identification
        /// </summary>
        SINGLE = 6
    }
}
