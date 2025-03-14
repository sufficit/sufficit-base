using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Named Call Group and Pickup Group
    /// </summary>
    public class EndPointGroups
    {
        /// <summary>
        ///     Witch groups can capture my calls
        /// </summary>
        [JsonPropertyName("call")]
        public HashSet<Guid> Call { get; set; }
            = new HashSet<Guid>();

        /// <summary>
        ///     Witch groups can i pickup from
        /// </summary>
        [JsonPropertyName("pickup")]
        public HashSet<Guid> PickUp { get; set; }
            = new HashSet<Guid>();

        public override bool Equals(object? obj)
            => obj is EndPointGroups other && Call.SetEquals(other.Call) && PickUp.SetEquals(other.PickUp);

        public override int GetHashCode()
            => (Call, PickUp).GetHashCode();
    }
}
