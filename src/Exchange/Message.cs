﻿using System;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange
{
    [Serializable]
    public class Message
    {
        public Message (Guid id, TChannel type = default)
        {
            this.Type = type;
            this.Id = id;
        }

        /// <summary>
        /// Channel type, like [ email,sms,whatsapp,telegram,webhook,etc ]
        /// </summary>
        [JsonPropertyOrder(0)]
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TChannel Type { get; }

        /// <summary>
        /// Unique identifier for this message, facilitate for logs
        /// </summary>
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual Guid Id { get; }

        [JsonPropertyOrder(0)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("recipient")]
        public virtual string Recipient { get; set; } = default!;

        /// <summary>
        /// Can be anonymous = null
        /// </summary>
        [JsonPropertyOrder(1)]
        [JsonPropertyName("emitter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Emitter { get; set; }

        [JsonPropertyOrder(2)]
        [JsonPropertyName("body")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual byte[]? Body { get; set; }
    }
}
