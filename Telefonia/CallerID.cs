using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telefonia
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
