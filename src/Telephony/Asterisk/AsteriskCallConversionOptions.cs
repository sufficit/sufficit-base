using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sufficit.Telephony.Asterisk
{
    public class AsteriskCallConversionOptions
    {
        public CancellationTokenSource CTS { get; set; } = default!;

        public uint MaxResults { get; set; }

        /// <summary>
        ///     If the max results was reached, continues until extended from last valid result
        /// </summary>
        public TimeSpan Extended { get; set; }
            = TimeSpan.FromHours(2);
    }
}