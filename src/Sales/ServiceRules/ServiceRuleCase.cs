using System;

namespace Sufficit.Sales
{
    /// <summary>Facts about one contract period, supplied by the caller. Dates are calendar dates (time ignored).</summary>
    public sealed class ServiceRuleCase
    {
        public DateTime DueDate { get; set; }

        /// <summary>Today, in the business time zone.</summary>
        public DateTime ReferenceDate { get; set; }

        /// <summary>Date the period was paid, if it was.</summary>
        public DateTime? PaidDate { get; set; }

        /// <summary>Authorized recurring card / active subscription.</summary>
        public bool AutomaticPayment { get; set; }
    }
}
