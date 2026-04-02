using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Request to transfer call balance between two client accounts.
    /// </summary>
    public class BalanceTransferRequest
    {
        /// <summary>Idempotency key. If not provided, the server will generate one.</summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>Source client context id (balance is taken from here).</summary>
        [JsonPropertyName("source_context_id")]
        public Guid SourceContextId { get; set; }

        /// <summary>Destination client context id (balance is added here).</summary>
        [JsonPropertyName("destination_context_id")]
        public Guid DestinationContextId { get; set; }

        /// <summary>Amount to transfer. Must be positive.</summary>
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        /// <summary>Optional description for the transfer.</summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
    }
}
