using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Grupos de sistema para saida de chamadas
    /// </summary>
    public class DialOutGroup
    {
        public string group { get; set; } = "UNKNOWN";
        public int prio { get; set; }
        public string title { get; set; } = default!;
        public string tech { get; set; } = "PJSIP";
        public int timeout { get; set; } = 30;
        public string? options { get; set; }
        public string? url { get; set; }
        public string? prepend { get; set; }
        public int remove { get; set; }

        public string? model { get; set; }
        public bool? idforward { get; set; }

        /// <summary>
        /// ID do provedor, usado para conferir se a DID a ser binada pertence ao mesmo fornecedor <br/>
        /// Caso em branco, significa que o provedor aceita envio de BINA aberta
        /// </summary>
        public Guid? idprovider { get; set; }

        /// <summary>
        /// Servidores onde o tronco esta instalado, ou caso em branco, todos os servidores
        /// </summary>
        public string servers { get; set; } = default!;

        public string? comments { get; set; }
    }
}
