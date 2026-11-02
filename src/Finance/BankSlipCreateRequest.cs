using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Sufficit.Finance
{
    /// <summary>
    /// Represents an asynchronous bank slip issuance request.
    /// </summary>
    public class BankSlipCreateRequest
    {
        public Guid ContextId { get; set; }
        public decimal Value { get; set; }
        public DateTime Expiration { get; set; }
        public string? Provider { get; set; }
        public string? Description { get; set; }
        public JsonElement? Attributes { get; set; }
        /// <summary>Optional services and competences charged; when present they must add up to <see cref="Value"/>.</summary>
        public List<BankSlipItem>? Items { get; set; }
    }
}
