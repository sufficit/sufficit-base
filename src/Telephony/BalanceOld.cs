using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class BalanceOld
    {
        /// <summary>
        ///     Client context identification
        /// </summary>        
        [JsonPropertyName("contextId")]
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Last Recharge applied
        /// </summary>
        [JsonPropertyName("chargeId")]
        public Guid ChargeId { get; set; }

        /// <summary>
        ///     Last Recharge take effective timestamp
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        ///     Current balance amount value
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        ///     Minimum or Maximum limit of balance
        /// </summary>
        [JsonPropertyName("limit")]
        public decimal? Limit { get; set; }

        [JsonIgnore]
        [Obsolete]
        public string? Client { get; set; }        
    }
}
