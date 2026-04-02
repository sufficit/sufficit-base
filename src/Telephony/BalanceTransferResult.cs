using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Result of a call balance transfer or revert operation.
    /// </summary>
    public class BalanceTransferResult
    {
        /// <summary>Id of the source record (used to revert this transfer).</summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>Timestamp of the operation (UTC).</summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>Source context id.</summary>
        [JsonPropertyName("source_context_id")]
        public Guid SourceContextId { get; set; }

        /// <summary>Destination context id.</summary>
        [JsonPropertyName("destination_context_id")]
        public Guid DestinationContextId { get; set; }

        /// <summary>Transferred call balance amount.</summary>
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        /// <summary>Description of the operation.</summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>Call balance of the source context immediately before the operation.</summary>
        [JsonPropertyName("source_previous_amount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal SourcePreviousAmount { get; set; }

        /// <summary>Call balance of the destination context immediately before the operation.</summary>
        [JsonPropertyName("destination_previous_amount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal DestinationPreviousAmount { get; set; }

        /// <summary>User who performed the operation.</summary>
        [JsonPropertyName("user_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid UserId { get; set; }

        /// <summary>Indicates this result is from a revert operation. Null for normal transfers.</summary>
        [JsonPropertyName("reverting")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Reverting { get; set; }

        /// <summary>Whether the transfer record is still active. Null when not queried from history.</summary>
        [JsonPropertyName("active")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Active { get; set; }
    }
}
