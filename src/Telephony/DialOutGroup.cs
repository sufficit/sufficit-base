﻿using System;
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
        public string group { get; set; }
        public int prio { get; set; }
        public string title { get; set; }
        public string tech { get; set; }
        public int timeout { get; set; }
        public string options { get; set; }
        public string url { get; set; }
        public string prepend { get; set; }
        public int remove { get; set; }

        public string model { get; set; }
        public bool idforward { get; set; }
        public string comments { get; set; }
    }
}