using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class BillingValueResponse
    {
        [JsonPropertyName("uniqueid")]
        public string UniqueId { get; set; } = default!;

        [JsonPropertyName("value")]
        public decimal Value { get; set; }
    }
}
