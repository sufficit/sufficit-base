using Sufficit.EFData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Registro de cobranças de chamadas telefonicas <br />
    /// Uma mesma chamada pode possuir vários registros <br />
    /// Pode ser processada por multiplos servidores e pode possuir multiplos destinos/encaminhamentos
    /// </summary>
    public class CallChargeRecordV1
    {
        /// <summary>
        /// Servidor por onde foi processada essa parte da chamada
        /// </summary>
        [Key, Column("servidor"), DefaultValue(""), MaxLength(255), Required]
        public string Server { get; set; }

        [Column("suffidcliente"), MaxLength(32), Required]
        public Guid IDContext { get; set; }

        /// <summary>
        /// Quando essa parte da chamada foi processada no servidor
        /// </summary>
        [Column("data"), Required]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }

        [Key, Column("id"), MaxLength(40), Required]
        public string UniqueID { get; set; }

        [Column("extensao"), DefaultValue(""), MaxLength(40), Required]
        public string Extension { get; set; }

        /// <summary>
        /// Valor calculado para esta parte da chamada
        /// </summary>
        [Column("valor"), Required]
        public decimal Value { get; set; }

        /// <summary>
        /// Descarte base aplicado ao calculo do valor
        /// </summary>
        [Column("descarte"), MaxLength(3), Required]
        public int Discard { get; set; }

        /// <summary>
        /// Mínimo de segundos base aplicado ao calculo do valor
        /// </summary>
        [Column("minimo"), MaxLength(3), Required]
        public int Minimum { get; set; }

        /// <summary>
        /// Cadência base aplicada ao calculo do valor
        /// </summary>
        [Column("cadencia"), MaxLength(3), Required]
        public int Cadence { get; set; }

        /// <summary>
        /// Custo base aplicado ao cálculo do valor
        /// </summary>
        [Column("custo"), Required]
        public decimal Cost { get; set; }

        /// <summary>
        /// Total de segundos cobrados por esta parte de chamada
        /// </summary>
        [Column("tempo"), MaxLength(11), Required]
        public int Seconds { get; set; }

    }
}
