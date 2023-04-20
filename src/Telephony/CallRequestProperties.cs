using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public class CallRequestProperties
    {
        /// <summary>
        /// Guid ID of Client or Telephony context
        /// </summary>       
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Use identified outbound calls
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Identified { get; set; }

        /// <summary>
        /// Prepend a label on caller name to internal users
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Label { get; set; }

        /// <summary>
        /// Apply a delay before calling
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Delay { get; set; }

        /// <summary>
        /// Call a internal asterisk extension
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Extension { get; set; }

        /// <summary>
        /// Await until call started, or return just after validate
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Await { get; set; } = false;
    }
}
