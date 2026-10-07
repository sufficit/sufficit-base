using System;

namespace Sufficit.Sales
{
    /// <summary>
    /// Whether a customer's service may be cancelled with a retroactive date without charge to its
    /// financial responsible. Internet providers learn of their customers' cancellations first and
    /// often forget to pass them on; established providers get this courtesy.
    /// </summary>
    /// <remarks>
    /// Rule (configurable): the financial responsible is an active representative, has been one for at
    /// least <see cref="MinMonths"/> months and pays the bills of at least <see cref="MinCustomers"/>
    /// active customers.
    /// </remarks>
    public class RetroactiveCancellationEligibility
    {
        public Guid CustomerId { get; set; }

        /// <summary>Active financial responsible of the customer, when there is one.</summary>
        public Guid? ResponsibleId { get; set; }
        public string? ResponsibleTitle { get; set; }

        public bool Eligible { get; set; }

        /// <summary>Plain-language explanation shown to the operator.</summary>
        public string Reason { get; set; } = string.Empty;

        /// <summary>Since when the responsible pays customers' bills (earliest active financial assignment).</summary>
        public DateTime? ResponsibleSinceUtc { get; set; }

        /// <summary>Active customers whose bills the responsible pays.</summary>
        public int Customers { get; set; }

        public int MinMonths { get; set; }
        public int MinCustomers { get; set; }
    }
}
