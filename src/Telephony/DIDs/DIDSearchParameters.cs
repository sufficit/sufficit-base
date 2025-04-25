using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.DIDs
{
    /// <summary>
    /// Direct Inward Dialing search parameters
    /// </summary>
    public class DIDSearchParameters : ILimit
    {
        /// <summary>Object unique id or null for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? Id { get; set; }

        /// <summary>Object unique id, null for all or empty for free</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ContextId { get; set; }

        /// <summary>Object Provider unique id or null for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonPropertyName("providerid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ProviderId { get; set; }

        /// <summary>Object Provider unique id or null for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonPropertyName("ownerid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? OwnerId { get; set; }

        [JsonPropertyName("extension")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextFilter? Extension { get; set; }

        /// <summary>
        ///     Dynamic search in all valid properties, using OR operator
        /// </summary>
        [JsonPropertyName("dynamic")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextFilter? Dynamic { get; set; }

        [JsonPropertyName("billed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Billed { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]       
        public uint? Limit { get; set; }
    }
}
