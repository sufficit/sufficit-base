using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Single object to be cached
    /// </summary>
    public class EndPointPropertyRequest
    {
        [JsonConstructor]
        public EndPointPropertyRequest() { Key = default!; }

        public EndPointPropertyRequest(string key) => Key = key;

        [JsonPropertyName("key")]
        public virtual string Key { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("contextid")]
        public Guid? ContextId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("endpointid")]
        public Guid? EndPointId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("value")]
        public virtual string? Value { get; set; }

        public override bool Equals(object? obj)
            => obj is EndPointPropertyRequest other && other.Key == Key && other.ContextId == ContextId && other.EndPointId == EndPointId && other.Value == Value;

        public override int GetHashCode()
            => (Key, ContextId, EndPointId, Value).GetHashCode();
    }
}
