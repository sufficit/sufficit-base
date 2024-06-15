using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public struct ContactAttributes
    {

        /// <summary>
        ///     Represents a carrier contact, to enlist carriers | providers
        /// </summary>
        public const string Carrier = "carrier";


        /// <summary>
        ///     Represents a balance notify information, limit value
        /// </summary>
        [Obsolete("2024/06/12 not used anymore")]
        public const string BalanceNotify = "telefonia_saldobaixoalerta";
    }
}
