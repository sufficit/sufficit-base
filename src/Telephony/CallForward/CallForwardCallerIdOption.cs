using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Sufficit.Telephony.CallForward
{
    /// <summary>
    /// An available outbound CallerID option for a call-forward rule.
    /// Returned by the callerid endpoint to populate the UI selector.
    /// </summary>
    [DataContract]
    public sealed class CallForwardCallerIdOption
    {
        /// <summary>DID number in E.164 or national format.</summary>
        [DataMember(Name = "number")]
        [JsonPropertyName("number")]
        public string Number { get; set; } = string.Empty;

        /// <summary>Human-readable label for the number.</summary>
        [DataMember(Name = "description")]
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
    }
}
