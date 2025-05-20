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
    public class CallRequestProperties
    {
        /// <summary>
        /// Guid ID of Client or Telephony context
        /// </summary>       
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Used for sincronize with external applications <br />
        ///     Chatwoot inbox identifier, etc
        /// </summary>
        [JsonPropertyName("externalid")]
        public string? ExternalId { get; set; }

        /// <summary>
        /// Use identified outbound calls
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("identified")]
        [Obsolete("use Alternative instead")]
        public bool Identified { set => Alternative = value; }

        /// <summary>
        /// Use alternative outbound calls, toggle identified
        /// </summary>
        [JsonPropertyName("alternative")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Alternative { get; set; }

        /// <summary>
        /// Prepend a label on caller name to internal users
        /// </summary>
        [JsonPropertyName("label")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Label { get; set; }

        /// <summary>
        /// Apply a delay before calling, milliseconds
        /// </summary>
        [JsonPropertyName("delay")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Delay { get; set; }

        /// <summary>
        /// Call a internal asterisk extension
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual string? Extension { get; set; }

        /// <summary>
        /// Await until call started, or return just after validate
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Await { get; set; } = false;

        #region OBSOLETE

        /// <summary>
        ///     Obsolete, use ContextId instead
        /// </summary>
        /// <remarks><see cref="ContextId"/></remarks>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(99)]
        [JsonPropertyName("idcontext")]
        [Obsolete("use ContextId instead")]
        public Guid? IdContext { set => ContextId = value.GetValueOrDefault(); get => ContextId; }

        #endregion
    }
}
