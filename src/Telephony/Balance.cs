using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class Balance
    {
        /// <summary>
        /// Client context identification
        /// </summary>
        [JsonPropertyName("contextId")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Last Recharge applied
        /// </summary>
        [JsonPropertyName("chargeId")]
        public Guid ChargeId { get; set; }

        /// <summary>
        /// Current balance value
        /// </summary>
        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        /// <summary>
        /// Minimum or Maximum limit of balance
        /// </summary>
        [JsonPropertyName("limit")]
        public decimal? Limit { get; set; }

        [JsonIgnore]
        [Obsolete]
        public string? Client { get; set; }

        [JsonPropertyName("timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }
    }
}
