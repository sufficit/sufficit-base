using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Contacts
{
    public class Address
    {
        /// <summary>
        ///     Postal code, Brazilian "CEP"
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        ///     Title, Brazilian "Logradouro"
        /// </summary>
        public string? Place { get; set; }

        /// <summary>
        ///     Street | Bulevard | Square | Road | ...
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        ///     Brazilian "Bairro"
        /// </summary>
        public string? Region { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? State { get; set; }

        public string? Extra { get; set; }
    }
}
