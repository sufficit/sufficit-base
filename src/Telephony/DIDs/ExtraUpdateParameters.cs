using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.DIDs
{
    public class ExtraUpdateParameters : IDirectInwardDialingExtra
    {
        public Guid Id { get; set; }

        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Description { get; set; }

        [JsonPropertyName("tags")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Tags { get; set; }
    }
}
