using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sufficit.Telephony.Asterisk.Manager
{
    public class AMIHubConnection
    {
        /// <summary>
        /// Servidor por onde foi processada essa parte da chamada
        /// </summary>
        [Key, Column("endpoint"), DefaultValue(""), MaxLength(255), Required]
        public string Endpoint { get; set; }
    }
}
