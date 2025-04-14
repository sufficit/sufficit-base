using System;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    /// <summary>
    ///     Request a single valid bankslip. (not expired)
    /// </summary>
    public class BankSlipRequest
    {
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        [JsonPropertyName("contextid")]
        public Guid? ContextId { get; set; }

        [JsonPropertyName("value")]
        public decimal? Value { get; set; }
    }
}
