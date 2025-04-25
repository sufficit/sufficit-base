using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public class Destination : DestinationBase, IDestination
    {
        /// <summary>
        /// Context of this destination
        /// </summary>
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }

        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual string? Title { get; set; }

        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual string? Description { get; set; }

        public override bool Equals(object? obj)
            => obj is Destination other &&
            other.ContextId == ContextId &&
            other.Title == Title &&
            other.Description == Description &&
            base.Equals(other);

        public override int GetHashCode()
            => (ContextId, Title, Description).GetHashCode() ^ base.GetHashCode();
    }
}