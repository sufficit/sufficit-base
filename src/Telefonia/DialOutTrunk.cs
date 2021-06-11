using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telefonia
{
    /// <summary>
    /// Tronco usado para discagem externa
    /// </summary>
    public class DialOutTrunk
    {
        public Guid context { get; set; }

        public string title { get; set; }

        public int channels { get; set; }
    }
}
