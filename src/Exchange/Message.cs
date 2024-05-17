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
            this.Id = id;
        }

        /// <summary>
        /// Unique identifier for this message, facilitate for logs
        /// </summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual Guid Id { get; }

        /// <summary>
        /// Channel type, like [ email,sms,whatsapp,telegram,webhook,etc ]
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TChannel Type { get; }

        /// <summary>
        /// Can be anonymous = null
        /// </summary>
        [JsonPropertyName("emitter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Emitter { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("recipient")]
        public string Recipient { get; set; } = default!;

        [JsonPropertyName("body")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual byte[]? Body { get; set; }
    }
}
