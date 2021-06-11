using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange.EMail
{
    public class EMailMessage : Message
    {
        public EMailMessage(Guid id) : base(id, TChannel.EMAIL) { }

        public string Subject { get; set; }

        public bool Trackable { get; set; } = true;

        public IEnumerable<MessageAttachment> Attachements { get; set; }
    }
}
