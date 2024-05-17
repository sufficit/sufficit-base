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
    public class CallBillingRecord
    {
        /// <summary>
        ///     Quando essa parte da chamada foi processada no servidor
        /// </summary>
        [Column("timestamp"), Required]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        ///     UniqueId for the call - prepended server names
        /// </summary>
        [Column("id"), MaxLength(40), Required]
        public string Id { get; set; } = default!;

        [Column("contextid"), Required]
        public Guid ContextId { get; set; }
        
        [Column("extension"), DefaultValue(""), MaxLength(40), Required]
        public string Extension { get; set; } = default!;

        [Column("match"), DefaultValue(""), MaxLength(45), Required]
        public string Match { get; set; } = default!;

        /// <summary>
        ///     Id for Service Provider, Brazilian Telephony Provider, STFC, Carrier <br />
        ///     This is the Provider Id applied for that record of billing <br />
        ///     It's NOT necessarily the Provider used for complete the dial 
        /// </summary>
        [Column("providerid"), Required]
        public Guid ProviderId { get; set; }

        /// <inheritdoc cref="CallDirection"/>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CallDirection Direction { get; set; }

        /// <inheritdoc cref="BillingCostIdForward"/>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BillingCostIdForward IdForward { get; set; }

        /// <summary>
        ///     Descarte base aplicado ao calculo do valor
        /// </summary>
        [Column("discard"), MaxLength(3), Required]
        public uint Discard { get; set; }

        /// <summary>
        ///     Mínimo de segundos base aplicado ao calculo do valor
        /// </summary>
        [Column("minimum"), DefaultValue((uint)30), MaxLength(3), Required]
        public uint Minimum { get; set; } = 30;

        /// <summary>
        ///     Cadência base aplicada ao calculo do valor
        /// </summary>
        [Column("cadence"), MaxLength(3), Required]
        public uint Cadence { get; set; }

        /// <summary>
        ///     Custo base aplicado ao cálculo do valor
        /// </summary>
        [Column("cost"), Required]
        public decimal Cost { get; set; }

        /// <summary>
        ///     Valor calculado para esta parte da chamada
        /// </summary>
        [Column("value"), Required]
        public decimal Value { get; set; }

        /// <summary>
        /// Total de segundos cobrados por esta parte de chamada
        /// </summary>
        [Column("seconds"), MaxLength(11), Required]
        public uint Seconds { get; set; }

        /// <summary>
        ///     Servidor por onde foi processada essa parte da chamada
        /// </summary>
        [Column("server"), DefaultValue(null), MaxLength(255)]
        public string? Server { get; set; }

        /// <summary>
        ///     Compara as taxas e o método de cobrança
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
