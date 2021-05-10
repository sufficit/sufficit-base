using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange.EMail
{
    public class EMailAttachement
    {
        public byte[] Content { get; set; }
        public string FileName { get; set; }
        public string MIME { get; set; }
    }
}
