using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Request for update balance informations like limits
    /// </summary>
    public sealed class BalancePatchRequest
    {
        /// <summary>
        /// Context to notify
        /// </summary>
        [JsonPropertyName("contextId")]
        public Guid ContextId { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? Limit { get; set; }
    }
}
