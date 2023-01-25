using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit
{
    /// <summary>
    /// DateTime start to end, prefer UTC
    /// </summary>
    public class DateTimeRange
    {
        /// <summary>
        /// Start date and time to filter
        /// </summary>
        public DateTime? Start { get; set; }


        /// <summary>
        /// End, limit date and time to filter
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// Use inclusive range, minor or grater and equals, or, just minor and grater comparisons
        /// </summary>
        public bool Inclusive { get; set; } = true;
    }
}
