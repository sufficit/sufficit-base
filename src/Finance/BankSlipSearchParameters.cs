using System;
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

        /// <summary>
        ///     Creation dateTime start to end, or exact match, prefer UTC
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTimeMatch? Timestamp { get; set; }

        /// <summary>
        ///    Expiration dateTime start to end, or exact match, prefer UTC
        /// </summary>
        [JsonPropertyName("expiration")]
        public DateTimeMatch? Expiration { get; set; }

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

        /// <summary>
        ///    Search only by expired or not expired records, null = "dont care" | both
        /// </summary>
        /// <remarks>*Not Expired, remarks to Not Received too</remarks>
        [JsonPropertyName("isexpired")]
        public bool? IsExpired { get; set; }

        /// <inheritdoc cref="BankSlipInfo.IsReceipt"/>
        [JsonPropertyName("isreceipt")]
        public bool? IsReceipt { get; set; }
    }
}
