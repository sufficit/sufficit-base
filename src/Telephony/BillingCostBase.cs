using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class BillingCostBase
    {       
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)] 
        public Guid ProviderId { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Extension { get; set; } = string.Empty;


        /// <inheritdoc cref="CallDirection"/>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)] 
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CallDirection Direction { get; set; }

        /// <summary>
        ///     Kind for cost id forward
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public BillingCostIdForward IdForward { get; set; }

        public decimal Cost { get; set; }

        /// <summary>
        ///     Anatel change the defaults to 0, it was 3
        /// </summary>
        public uint Discard { get; set; } = 0;

        /// <summary>
        ///     Minimum amount to calculate value 
        /// </summary>
        public uint Minimum { get; set; } = 30;

        /// <summary>
        ///     Pulse, interval that matches to calculate value
        /// </summary>
        public uint Cadence { get; set; } = 30;

        /// <summary>
        ///     Calcular o Valor com as informações atuais
        /// </summary>
        public decimal Calculate(long duration) 
            => Calculate(this.Discard, this.Minimum, this.Cadence, this.Cost, duration);

        /// <summary>
        ///     Caluculo genérico de valores para chamadas
        /// </summary>
        public static decimal Calculate(uint discard, uint minimum, uint cadence, decimal cost, long seconds)
        {
            decimal value = 0;
            if (seconds > discard)
            {
                if (seconds > minimum)
                {
                    int ticks = (int)Math.Ceiling((double)seconds / (double)cadence);
                    value = (cost / (60 / cadence)) * ticks;
                }
                else { value = cost / (60 / minimum); }
            }
            return value;
        }
    }
}
