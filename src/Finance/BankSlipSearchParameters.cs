﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    public class BankSlipSearchParameters : ILimit
    {
        [JsonPropertyName("contextid")]
        public Guid? ContextId { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        [JsonPropertyName("limit")]
        public uint? Limit { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTimeMatch? Timestamp { get; set; }

        /// <summary>
        ///     Exact value for search
        /// </summary>
        [JsonPropertyName("value")]
        public decimal? Value { get; set; }

        /// <summary>
        ///     Search only by active or inactive records, null = "dont care" | both
        /// </summary>
        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        /// <inheritdoc cref="BankSlipInfo.IsReceipt"/>
        [JsonPropertyName("isreceipt")]
        public bool? IsReceipt { get; set; }
    }
}
