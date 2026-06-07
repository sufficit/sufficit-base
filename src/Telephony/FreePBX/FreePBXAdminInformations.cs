using System;

namespace Sufficit.Telephony.FreePBX
{
    /// <summary>
    ///     Cached FreePBX admin panel information (pending reload state, last reload timestamp).
    /// </summary>
    public class FreePBXAdminInformations
    {
        /// <summary>
        ///     Date time for the last database retrieve
        /// </summary>
        public DateTime Timestamp { get; set; }

        public bool Pending { get; set; }

        public DateTime? Reload { get; set; }
    }
}
