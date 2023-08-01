using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Registro de Recarga de Saldo de Telefonia <br />
    /// Tronco Tarifado
    /// </summary>
    public class BalanceChargeRecord
    {
        [Key, Column("idrecarga", TypeName = "char(36)")]
        public Guid Id { get; set; }

        [Column("idcliente", TypeName = "char(36)")]
        public Guid ContextId { get; set; }

        public DateTime Date { get; set; }

        /// <summary>
        /// Valor da recarga realizada
        /// </summary>
        [Column(TypeName = "decimal(6,4)")]
        public decimal Value { get; set; }

        /// <summary>
        /// Saldo antes de efetivar a recarga
        /// </summary>
        [Column(TypeName = "decimal(6,4)")]
        public decimal Balance { get; set; }

        public DateTime Expiration { get; set; }

        public string Client { get; set; } = string.Empty;
    }
}
