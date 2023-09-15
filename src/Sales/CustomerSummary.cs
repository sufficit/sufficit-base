using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Sales
{
    public class CustomerSummary
    {
        public CustomerSummary(Customer customer) => Customer = customer;

        public Customer Customer { get; }

        public decimal? Mensal { get; set; }

        /// <summary>
        ///     Financial contact
        /// </summary>
        public string? EMail { get; set; }

        /// <summary>
        ///     Has commissions to receive
        /// </summary>
        public bool Commissioned { get; set; }

        /// <summary>
        ///     Has billed trunk service
        /// </summary>
        public bool Billed { get; set; }
    }
}
