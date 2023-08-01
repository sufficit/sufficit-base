using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Kind for cost id forward
    /// </summary>
    //ENUM('FIXED','RANDOM','INTELIGENT','ANY')
    public enum BillingCostIdForward : short
    {
        /// <summary>
        ///     Don't care, same cost for all
        /// </summary>
        ANY,

        /// <summary>
        ///     Fixed number to id, default for any brazilian carrier
        /// </summary>
        FIXED,

        /// <summary>
        ///     Random id, flex trunk
        /// </summary>
        RANDOM,

        /// <summary>
        ///     Local client id, same DDD
        /// </summary>
        SMART,
    }
}
