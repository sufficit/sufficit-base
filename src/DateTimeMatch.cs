using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit
{
    /// <summary>
    ///     DateTime start to end, or exact match, prefer UTC
    /// </summary>
    public class DateTimeMatch : DateTimeRange
    {
        /// <summary>
        ///     Exact match, ignoring "start" and "end" values
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("exact")]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime? Exact { get; set; }
    }
}
