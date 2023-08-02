using System;
using System.Text.Json.Serialization;

namespace Sufficit.Logging
{
    /// <summary>
    ///     Long term event registration
    /// </summary>
    public class JsonLog : LogBase
    {
        [JsonPropertyName("content")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual string? Content { get; set; }
    }
}
