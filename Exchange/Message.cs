using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange
{
    [Serializable]
    public class Message
    {
        public Message(Guid id, TChannel type = default)
        {
            this.Type = type;
            this.ID = id;
            this.Emitter = this.Recipient = string.Empty;
            this.Body = null;
        }

        #region PROPRIEDADES

        public Guid ID { get; }
        public TChannel Type { get; }
        public string Emitter { get; set; }
        public string Recipient { get; set; }
        public byte[] Body { get; set; }

        #endregion
    }
}
