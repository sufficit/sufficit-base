using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public class DestinationBase
    {
        /// <summary>
        /// Unique Id of this destination
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Section|Class of the reference destination
        /// </summary>
        [JsonPropertyName("typeName")]
        public virtual string TypeName { get; set; } = default!;

        /// <summary>
        /// Asterisk Goto representation
        /// </summary>
        [JsonPropertyName("asterisk")]
        public virtual string Asterisk { get; set; } = default!;

        public override bool Equals(object? obj)
            => obj is DestinationBase other && 
            other.Id == Id && 
            other.TypeName == TypeName && 
            other.Asterisk == Asterisk;

        public override int GetHashCode()
            => (Id, TypeName, Asterisk).GetHashCode();
    }
}