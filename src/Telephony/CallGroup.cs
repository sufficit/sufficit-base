using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Represents a group of endpoints or destinations for dialplan control usage
    /// </summary>
    public class CallGroup
    {        
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        public override bool Equals(object? obj)
            => obj is CallGroup other && other.Id == Id && other.ContextId == ContextId && other.Title == Title && other.Description == Description;

        public override int GetHashCode()
            => (Id, ContextId, Title, Description).GetHashCode();
    }
}
