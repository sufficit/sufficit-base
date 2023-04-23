using System;
using System.Collections.Generic;

namespace Sufficit.Provisioning
{
    /// <summary>
    /// Contact search parameters
    /// </summary>
    public class DeviceSearchParameters
    {        
        public Guid? ContextId { get; set; }
        
        public Guid? ExtensionId { get; set; }

        public string? MACAddress { get; set; }

        public string? IPAddress { get; set; }

        public uint Limit { get; set; }
    }
}
