using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    public class BankSlipInfo
    {
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public Guid Id { get; set; }

        /// <summary>
        ///     Customer Id
        /// </summary>
        [JsonPropertyOrder(1)]
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public Guid ContextId { get; set; }

        [JsonPropertyOrder(2)]
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public decimal Value { get; set; }

        [JsonPropertyOrder(3)]
        [JsonPropertyName("expiration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Expiration { get; set; }

        [JsonPropertyOrder(3)]
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        ///     Date and time that the payment was regnized by the bank
        /// </summary>
        [JsonPropertyOrder(3)]
        [JsonPropertyName("receipt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Receipt { get; set; }

        [JsonPropertyOrder(4)]
        [JsonPropertyName("active")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public bool Active { get; set; } = true;

        [JsonPropertyOrder(6)]
        [JsonPropertyName("barcode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? BarCode { get; set; }

        /// <summary>
        /// Url for preview
        /// </summary>
        [JsonPropertyOrder(7)]
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Url { get; set; }

        /// <summary>
        ///     Is Receipt
        /// </summary>
        [JsonPropertyOrder(8)]
        [JsonPropertyName("isreceipt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public bool IsReceipt => Receipt.HasValue && Receipt > DateTime.MinValue;

        /// <summary>
        ///     Is Expired
        /// </summary>
        [JsonPropertyOrder(8)]
        [JsonPropertyName("isexpired")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public bool IsExpired => !IsReceipt && Expiration < DateTime.UtcNow;
    }
}
