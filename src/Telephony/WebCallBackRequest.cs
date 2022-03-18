using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public class WebCallBackRequest
    {
        /// <summary>
        /// Guid ID of Client or Telephony context
        /// </summary>
        public Guid IDContext { get; set; }

        // Use identified outbound calls
        public bool Identified { get; set; }

        // Prepend a label on caller name to internal users
        public string Label { get; set; }

        // Destination phone
        public string Destination { get; set; }

        // Apply a delay before calling
        public int Delay { get; set; }

        /// <summary>
        /// Call a internal extension
        /// </summary>
        public string Extension => throw new NotImplementedException();
    }
}
