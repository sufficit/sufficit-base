using System;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange
{
    [Serializable]
    public class Message
    {
        public Message(Guid id, TChannel type = default)
        {
            this.Type = type;
            this.ID = id;
        }

        /// <summary>
        /// Unique identifier for this message, facilitate for logs
        /// </summary>
        [JsonPropertyName("id")]
        public Guid ID { get; }

        /// <summary>
        /// Optional Guid to indicate a message model or context, facilitate for track systems
        /// </summary>
        [JsonPropertyName("model")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? Model { get; set; }

        /// <summary>
        /// Channel type, like [ email,sms,whatsapp,telegram,etc ]
        /// </summary>
        [JsonPropertyName("type")]
        public TChannel Type { get; }

        /// <summary>
        /// Can be anonymous = null
        /// </summary>
        [JsonPropertyName("emitter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Emitter { get; set; }

        [JsonPropertyName("recipient")]
        public string Recipient { get; set; } = default!;

        [JsonPropertyName("body")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual byte[]? Body { get; set; }
    }
}
