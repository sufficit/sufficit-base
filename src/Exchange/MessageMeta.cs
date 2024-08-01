using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange
{
    /// <summary>
    ///     Basic info about message, just for statistics or read receipts methods
    /// </summary>
    public class MessageMeta
    {
        /// <summary>
        ///     Unique Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("channel")]
        public TChannel Channel { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
