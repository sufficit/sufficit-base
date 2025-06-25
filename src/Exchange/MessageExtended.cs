using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange
{
    /// <summary>
    ///     Default Message + Context + Reference + Model
    /// </summary>
    [Serializable]
    public class MessageExtended : Message, IMessageExtendedInfo
    {
        public MessageExtended(Guid id, TChannel type = default) : base(id, type) { }

        /// <inheritdoc cref="IMessageExtendedInfo.ModelId"/>
        [JsonPropertyOrder(1)]
        [JsonPropertyName("modelid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ModelId { get; set; }

        /// <inheritdoc cref="IMessageExtendedInfo.ReferenceId"/>
        [JsonPropertyOrder(1)]
        [JsonPropertyName("referenceid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ReferenceId { get; set; }

        /// <inheritdoc cref="IMessageExtendedInfo.ContextId"/>
        [JsonPropertyOrder(1)]
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }
    }
}
