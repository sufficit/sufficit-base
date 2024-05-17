﻿using System;
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
        [JsonPropertyName("modelid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ModelId { get; set; }

        /// <inheritdoc cref="IMessageExtendedInfo.ReferenceId"/>
        [JsonPropertyName("referenceid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ReferenceId { get; set; }

        /// <inheritdoc cref="IMessageExtendedInfo.ContextId"/>
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }
    }
}
