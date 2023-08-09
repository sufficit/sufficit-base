using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit
{
    /// <summary>
    ///     DateTime start to end, or exact match, prefer UTC
    /// </summary>
    public class DateTimeMatch : DateTimeRange
    {
        /// <summary>
        ///     Exact match, ignoring "start" and "end" values
        /// </summary>
        public DateTime? Exact { get; set; }
    }
}
