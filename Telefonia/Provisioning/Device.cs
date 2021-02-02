using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telefonia.Provisioning
{
    public class Device
    {
        public Guid IDContext { get; set; }
        public Guid IDExtension { get; set; }
        public string MACAddress { get; set; }
    }
}
