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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public uint? Limit { get; set; }

        /// <summary>
        ///     Creation dateTime start to end, or exact match, prefer UTC
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTimeMatch? Timestamp { get; set; }

        /// <summary>
        ///    Expiration dateTime start to end, or exact match, prefer UTC
        /// </summary>
        [JsonPropertyName("expiration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTimeMatch? Expiration { get; set; }

        /// <summary>
        ///     Exact value for search
        /// </summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public decimal? Value { get; set; }

        /// <summary>
        ///     Search only by active or inactive records, null = "dont care" | both
        /// </summary>
        [JsonPropertyName("active")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Active { get; set; }

        /// <summary>
        ///    Search only by expired or not expired records, null = "dont care" | both
        /// </summary>
        /// <remarks>*Not Expired, remarks to Not Received too</remarks>
        [JsonPropertyName("isexpired")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsExpired { get; set; }

        /// <inheritdoc cref="BankSlipInfo.IsReceipt"/>
        [JsonPropertyName("isreceipt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsReceipt { get; set; }

        /// <inheritdoc cref="BankSlipInfo.Receipt"/>
        /// <remarks>*exact => compares only dates, no time</remarks>
        [JsonPropertyName("receipt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTimeMatch? Receipt { get; set; }
    }
}
