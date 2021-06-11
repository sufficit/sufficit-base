using System;
using System.Runtime.Serialization;
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
        }

        #region PROPRIEDADES

        public Guid ID { get; }
        public TChannel Type { get; }
        public string Emitter { get; set; }
        public string Recipient { get; set; }
        public virtual byte[] Body { get; set; }

        #endregion
    }
}
