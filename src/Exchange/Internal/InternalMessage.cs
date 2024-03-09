using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Sufficit.Exchange.Internal
{
    public class InternalMessage : Message
    {
        public InternalMessage(Guid id) : base(id, TChannel.INTERNAL) { }

        public InternalMessage() : base(Guid.NewGuid(), TChannel.INTERNAL) { }

        /// <summary>
        ///     Used to switch and deserializations
        /// </summary>
        [JsonPropertyName("modelid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual Guid ModelId { get; set; }

        [JsonPropertyName("body")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public new object? Body
        {
            get => base.Body != null ? JsonSerializer.Deserialize<JsonNode>(base.Body) : null;
            set => base.Body = value?.ToString() != null ? Encoding.UTF8.GetBytes(value.ToString()!) : null;
        }
    }
}
