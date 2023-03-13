using Sufficit.Telephony.Asterisk;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.DIDs
{
    /// <summary>
    /// Direct Inward Dialing search parameters
    /// </summary>
    public class DIDSearchParameters
    {
        /// <summary>Object unique id or null for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? Id { get; set; }

        /// <summary>Object unique id, null for all or empty for free</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ContextId { get; set; }

        /// <summary>Object Provider unique id or null for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ProviderId { get; set; }

        /// <summary>Object Provider unique id or null for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? OwnerId { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextFilter? Extension { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Billed { get; set; }

        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        /// <example><code>0</code></example>
        public int Limit { get; set; }
    }
}
