using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Registro de Recarga de Saldo de Telefonia <br />
    ///     Tronco Tarifado
    /// </summary>
    public class BalanceChargeRecord
    {
        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Valor da recarga realizada
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        ///     Previous balance ammount, before activates this charge
        /// </summary>
        public decimal Balance { get; set; }

        public DateTime Expiration { get; set; }

        [Obsolete]
        public string Client { get; set; } 
            = string.Empty;
    }
}
