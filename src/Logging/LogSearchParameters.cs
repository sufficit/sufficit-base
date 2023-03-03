using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Logging
{
    public class LogSearchParameters
    {
        /// <inheritdoc cref="LogBase.ClassName"/>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextFilter? ClassName { get; set; }

        /// <inheritdoc cref="LogBase.Timestamp"/>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTimeRange? Timestamp { get; set; }

        /// <inheritdoc cref="LogBase.Expiration"/>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTimeRange? Expiration { get; set; }

        /// <inheritdoc cref="LogBase.ContextId"/>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ContextId { get; set; }

        /// <inheritdoc cref="LogBase.Reference"/>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Reference { get; set; }

        /// <inheritdoc cref="LogBase.UserId"/>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? UserId { get; set; }

        /// <example><code>0</code></example>
        [DataMember(Name = "limit", IsRequired = false)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Limit { get; set; } = 10;
    }
}
