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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual string? Title { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual string? Description { get; set; }

        public override bool Equals(object? obj)
            => obj is Destination other && 
            other.Id == Id && 
            other.TypeName == TypeName && 
            other.ContextId == ContextId && 
            other.Asterisk == Asterisk && 
            other.Title == Title && 
            other.Description == Description;

        public override int GetHashCode()
            => (Id, TypeName, ContextId, Asterisk, Title, Description).GetHashCode();
    }
}