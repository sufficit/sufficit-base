using Sufficit.Telephony;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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

        /// <summary>
        ///     Simple text filter
        /// </summary>
        public string? Filter { get; set; }

        public uint Limit { get; set; }

        public OrderBy? Order { get; set; }
    }
}
