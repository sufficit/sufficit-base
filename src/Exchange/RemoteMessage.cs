using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange
{
    /// <summary>
    ///     External source message
    /// </summary>
    public class RemoteMessage : Message
    {
        public RemoteMessage(Guid id, TChannel type = default) : base(id, type)
        {

        }

        /// <summary>
        ///     Source unique identifier
        /// </summary>
        [JsonPropertyName("externalid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? ExternalId { get; set; }
    }
}
