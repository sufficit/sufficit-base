using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sufficit.Sales
{
    public class Customer
    {
        public Guid Id { get; set; }

        /// <summary>
        ///     Month day that expires the services
        /// </summary>
        [Range(1, 31)]
        public uint? DueDay { get; set; }
    }
}