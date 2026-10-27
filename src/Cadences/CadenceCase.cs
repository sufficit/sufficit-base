using System;
using System.Collections.Generic;

namespace Sufficit.Cadences
{
    /// <summary>Facts about one case, supplied by the consumer. Dates are calendar dates (time ignored).</summary>
    public sealed class CadenceCase
    {
        /// <summary>The anchor date of the cadence (due date, coverage end, event date...).</summary>
        public DateTime AnchorDate { get; set; }

        /// <summary>Today, in the business time zone.</summary>
        public DateTime ReferenceDate { get; set; }

        /// <summary>Date the case was resolved (paid, renewed, answered), if it was.</summary>
        public DateTime? ResolvedDate { get; set; }

        /// <summary>Facts that hold for this case; steps whose condition is listed here are skipped.</summary>
        public HashSet<string> Facts { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    }
}
