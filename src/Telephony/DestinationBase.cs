using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public class DestinationBase : Sufficit.Telephony.Asterisk.IAsterisk
    {
        /// <summary>
        /// Unique Id of this destination
        /// </summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Section|Class of the reference destination
        /// </summary>
        [JsonPropertyName("typename")]
        public virtual string TypeName { get; set; } = default!;

        /// <inheritdoc cref="Sufficit.Telephony.Asterisk.IAsterisk.Asterisk"/>
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