using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange
{
    public class MessageAttachment
    {
        /// <summary>
        /// Propriedade que indica o tipo de conteudo do anexo
        /// </summary>
        public string MIME { get; set; }

        public byte[] Body { get; set; }
    }
}
