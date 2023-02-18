using Sufficit.Telephony.Asterisk;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Direct Inward Dialing search parameters
    /// </summary>
    public class CallQueueSearchParameters
    {
        /// <summary>Object unique id or null for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? Id { get; set; }

        /// <summary>Object unique id, null for all or empty for free</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ContextId { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextFilter? Agent { get; set; }


        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        /// <example><code>0</code></example>
        public int Limit { get; set; }
    }
}
