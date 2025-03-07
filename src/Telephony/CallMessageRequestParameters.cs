using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sufficit.Telephony
{
    public class CallMessageRequestParameters
    {
        /// <summary>
        /// Guid ID of Client or Telephony context
        /// </summary>       
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Call a external destinations
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public HashSet<string> Destinations { get; set; } = new HashSet<string>();

        /// <summary>
        /// Message to be transcripted and sent
        /// </summary>
        public string Message { get; set; } = default!;

        /// <summary>
        ///     Used for sincronize with external applications <br />
        ///     Chatwoot inbox identifier, etc
        /// </summary>
        [JsonPropertyName("externalid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? ExternalId { get; set; }

        /// <summary>
        /// Use identified outbound calls
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("identified")]
        public bool? Identified { get; set; }

        /// <summary>
        /// Prepend a label on caller name to internal users
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Label { get; set; }

        /// <summary>
        /// Apply a delay before calling, milliseconds
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public int? Delay { get; set; }


        /// <summary>
        /// Await until call started, or return just after validate
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Await { get; set; } = false;
    }
}
