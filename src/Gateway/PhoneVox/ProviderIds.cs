using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.PhoneVox
{
    public class ProviderIds
    {
        [JsonPropertyName("comercial")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Comercial { get; set; }

        [JsonPropertyName("support")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Support { get; set; }
        
        [JsonPropertyName("finance")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Finance { get; set; }

        [JsonPropertyName("other")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Other { get; set; }
    }
}
