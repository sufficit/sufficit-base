using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class EndPointSearchParameters
    {
        /// <summary>Object unique id or null for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? UserId { get; set; }

        /// <summary>Object unique id, null for all or empty for free</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ContextId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextFilter? Title { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextFilter? Description { get; set; }

        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        /// <example><code>0</code></example>
        public int Limit { get; set; }
    }
}
