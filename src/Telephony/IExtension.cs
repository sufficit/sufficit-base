using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Represents an internal extension, device address 
    /// </summary>
    public interface IExtension
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid ID { get; }

        /// <summary>
        /// Client unique identifier
        /// </summary>
        public Guid IDContext { get; }

        /// <summary>
        /// Priority id for outbound calls
        /// </summary>
        public string? OutBoundCallerId { get; }

        public string Description { get; }
    }
}
