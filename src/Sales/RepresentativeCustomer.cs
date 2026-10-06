using System;
using System.Collections.Generic;

namespace Sufficit.Sales
{
    /// <summary>
    /// One row of a sales representative's panel: the representative itself or a customer
    /// currently commissioned to it, with the aggregate figures the panel displays.
    /// </summary>
    /// <remarks>Carries totals only; never the customer's individual commercial records.</remarks>
    public class RepresentativeCustomer
    {
        /// <summary>Customer (contact) identity.</summary>
        public Guid Id { get; set; }

        /// <summary>Customer display title.</summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>True for the representative's own row, listed first.</summary>
        public bool IsRepresentative { get; set; }

        /// <summary>Financial ledger balance (not the telephony calling balance).</summary>
        public decimal Balance { get; set; }

        /// <summary>Sum of the values of the customer's services active now.</summary>
        public decimal Commitment { get; set; }

        /// <summary>Number of the customer's services active now.</summary>
        public int ActiveServices { get; set; }

        /// <summary>Notes (DIDs) of the customer's active inbound trunk services.</summary>
        public IList<string> Entries { get; set; } = new List<string>();
    }
}
