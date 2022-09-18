using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sufficit.Telephony
{
    public class Balance
    {
        public Guid IDContext { get; set; }

        /// <summary>
        /// Última recarga que foi aplicada
        /// </summary>
        public Guid IDCharge { get; set; }

        /// <summary>
        /// Current balance value
        /// </summary>
        public decimal Value { get; set; }

        public string? Client { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Updated { get; set; }
    }
}
