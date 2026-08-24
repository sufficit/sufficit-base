using System;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    public sealed class N8nAsaasInvoiceCancellationRequest
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("sourceid")]
        public string? SourceId { get; set; }
    }
}
