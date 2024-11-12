using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class MusicOnHoldSearchParameters
    {
        /// <summary>Unique id or empty for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? Id { get; set; }

        /// <summary>Context id or empty for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ContextId { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextFilter? Title { get; set; }

        /// <summary>
        ///     returns only no titled matches, ignores Title text filter
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool NoTitle { get; set; }
    }
}
