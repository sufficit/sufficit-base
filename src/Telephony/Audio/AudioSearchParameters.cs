using System;

namespace Sufficit.Telephony.Audio
{
    /// <summary>
    /// Interactive Voice Response search parameters
    /// </summary>
    public class AudioSearchParameters
    {
        /// <summary>IVR unique id or empty for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? AudioId { get; set; }

        /// <summary>IVR unique id or empty for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? ContextId { get; set; }

        public string? Title { get; set; }
    }
}
