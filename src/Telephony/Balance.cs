﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class Balance
    {
        /// <summary>
        ///     Client context identification
        /// </summary>
        [JsonPropertyName("contextid")]
        [Key]
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Last Recharge applied
        /// </summary>
        [JsonPropertyName("chargeid")]
        public Guid ChargeId { get; set; }

        /// <summary>
        ///     Last Recharge take effective timestamp
        /// </summary>
        [JsonPropertyName("timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
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
    }
}
