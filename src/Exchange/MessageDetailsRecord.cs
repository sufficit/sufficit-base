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
        public string? Content { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Update { get; set; }
    }
}
