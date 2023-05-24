using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Custom devices attribute for configuration
    /// </summary>
    public class DeviceAttribute
    {    
        [JsonPropertyName("macaddress")]
        public string MACAddress { get; set; } = default!;

        [JsonPropertyName("key")]
        public string Key { get; set; } = default!;

        [JsonPropertyName("value")]
        public string Value { get; set; } = default!;
    }
}
