using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange.Telegram
{
    public class TelegramMessage : RemoteMessage
    {
        public TelegramMessage(Guid id) : base(id, TChannel.TELEGRAM)
        {
            Chat = new TelegramChat();
        }
        
        [JsonConstructor]
        public TelegramMessage(Guid id, TelegramChat chat) : base(id, TChannel.TELEGRAM)
        {
            Chat = chat;
        }
        
        [JsonPropertyName("chat")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TelegramChat Chat { get; }

        [JsonPropertyName("attachment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MessageAttachment? Attachment { get; set; }

        [JsonPropertyOrder(0)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("recipient")]
        public override string Recipient
        {
            get => Chat.Id.ToString();
            set
            {
                if (long.TryParse(value, out long chatId))
                {
                    Chat.Id = chatId;
                }
                else
                {
                    throw new ArgumentException($"Invalid Telegram chat ID: {value}");
                }
            }
        }
    }
}
