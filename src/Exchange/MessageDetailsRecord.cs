using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange
{
    /// <summary>
    ///     Used to log details of messages
    /// </summary>
    public class MessageDetailsRecord : MessageDetails
    {
        [JsonPropertyName("content")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Content { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        [JsonPropertyName("update")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Update { get; set; }
    }
}
