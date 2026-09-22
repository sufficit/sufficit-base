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
        /// <remarks>
        ///     <paramref name="cost"/> is the price of a minute, so a slice of <paramref name="cadence"/>
        ///     seconds costs <c>cost * cadence / 60</c>. The old code wrote it as <c>cost / (60 / cadence)</c>,
        ///     an integer division that only holds for cadences that divide 60 and throws for a cadence
        ///     above 60. A cadence of zero means the whole minute.
        /// </remarks>
        public static decimal Calculate(uint discard, uint minimum, uint cadence, decimal cost, long seconds)
        {
            if (seconds <= discard)
                return 0;

            if (seconds <= minimum)
                return cost * minimum / 60m;

            if (cadence == 0)
                cadence = 60;

            // whole slices, rounded up, without going through floating point
            long ticks = (seconds + cadence - 1) / cadence;
            return cost * cadence * ticks / 60m;
        }
    }
}
