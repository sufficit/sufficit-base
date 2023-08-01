using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Registro de cobranças de chamadas telefonicas <br />
    ///     Uma mesma chamada pode possuir vários registros <br />
    ///     Pode ser processada por multiplos servidores e pode possuir multiplos destinos/encaminhamentos
    /// </summary>
    public class CallBillingRecordOld
    {
        /// <summary>
        ///     Quando essa parte da chamada foi processada no servidor
        /// </summary>
        [Column("data"), Required]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        ///     UniqueId for the call - prepended server names
        /// </summary>
        [Column("id"), MaxLength(40), Required]
        public string Id { get; set; } = default!;

        [Column("extensao"), DefaultValue(""), MaxLength(40), Required]
        public string Extension { get; set; } = default!;


        [Column("suffidcliente"), Required]
        public Guid ContextId { get; set; }
        
        /// <summary>
        ///     Descarte base aplicado ao calculo do valor
        /// </summary>
        [Column("descarte"), MaxLength(3), Required]
        public uint Discard { get; set; }

        /// <summary>
        ///     Mínimo de segundos base aplicado ao calculo do valor
        /// </summary>
        [Column("minimo"), DefaultValue(30), MaxLength(3), Required]
        public uint Minimum { get; set; }

        /// <summary>
        ///     Cadência base aplicada ao calculo do valor
        /// </summary>
        [Column("cadencia"), MaxLength(3), Required]
        public uint Cadence { get; set; }

        /// <summary>
        ///     Custo base aplicado ao cálculo do valor
        /// </summary>
        [Column("custo"), Required]
        public decimal Cost { get; set; }

        /// <summary>
        ///     Valor calculado para esta parte da chamada
        /// </summary>
        [Column("valor"), Required]
        public decimal Value { get; set; }

        /// <summary>
        /// Total de segundos cobrados por esta parte de chamada
        /// </summary>
        [Column("tempo"), MaxLength(11), Required]
        public uint Seconds { get; set; }

        /// <summary>
        ///     Servidor por onde foi processada essa parte da chamada
        /// </summary>
        [Column("servidor"), DefaultValue(null), MaxLength(255)]
        public string? Server { get; set; }

        /// <summary>
        /// Compara as taxas e o método de cobrança
        /// </summary>
        public bool RateCompare(CallBillingRecord obj)
        {
            if (obj != null)
            {
                if (obj.Value == Value)
                    if (obj.Cost == Cost)
                        if (obj.Discard == Discard)
                            if (obj.Minimum == Minimum)
                                if (obj.Cadence == Cadence)
                                    return true;
            }

            return base.Equals(obj);
        }
    }
}
