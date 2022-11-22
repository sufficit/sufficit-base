using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange.Telegram
{
    public class TelegramMessage : Message
    {
        public TelegramMessage(Guid id) : base(id, TChannel.TELEGRAM)
        {
            
        }

        public TelegramChat Chat;

        public MessageAttachment? Attachment { get; set; }
    }
}
