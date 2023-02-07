using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.DIDs
{
    public class FilterUpdateParameters
    {
        public Guid Id { get; set; }

        [JsonPropertyName("filter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Filter { get; set; }
    }
}
