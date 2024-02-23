using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public class EndPointPropertyRequestMany
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("contextid")]
        public virtual Guid? ContextId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("endpointid")]
        public Guid? EndPointId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("key")]
        public virtual string? Key { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("value")]
        public virtual string? Value { get; set; }

        public override bool Equals(object? obj)
            => obj is EndPointPropertyRequestMany other && other.ContextId == ContextId && other.EndPointId == EndPointId && other.Key == Key && other.Value == Value;

        public override int GetHashCode()
            => (ContextId, EndPointId, Key, Value).GetHashCode();
    }
}
