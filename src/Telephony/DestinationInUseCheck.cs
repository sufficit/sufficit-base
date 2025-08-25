using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Represents a check for whether a destination is in use
    /// </summary>
    public class DestinationInUseCheck
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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? TypeName { get; set; }

        [JsonPropertyName("asterisk")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Asterisk { get; set; }

        public override bool Equals(object? obj)
            => obj is DestinationInUseCheck other && 
            other.Id == Id && 
            other.TypeName == TypeName && 
            other.Asterisk == Asterisk;

        public override int GetHashCode()
            => (Id, TypeName, Asterisk).GetHashCode();
    }
}