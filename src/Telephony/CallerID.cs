using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Identificador de chamadas
    /// </summary>
    public class CallerID
    {
        public Guid id { get; set; }

        public string num { get; set; }

        public string name { get; set; }           
    }
}
