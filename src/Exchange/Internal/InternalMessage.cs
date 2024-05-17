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
        [JsonIgnore]
        public Encoding Encoding { get; set; } = Encoding.UTF8;

        [JsonConstructor]
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
            get
            {
                if (base.Body == null) 
                    return null;

                try
                {
                    return JsonSerializer.Deserialize<JsonNode>(base.Body);
                }
                catch
                {
                    return Encoding.GetString(base.Body);
                }
            }

            set => base.Body = value?.ToString() != null ? Encoding.GetBytes(value.ToString()!) : null;
        }
    }
}
