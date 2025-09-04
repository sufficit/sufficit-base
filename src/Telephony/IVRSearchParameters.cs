using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Interactive Voice Response search parameters
    /// </summary>
    public class IVRSearchParameters
    {
        /// <summary>
        /// Default name for IVR Id parameter
        /// </summary>
        public const string IVRID = "ivrid";

        /// <summary>IVR unique id or empty for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonPropertyName(IVRID)]
        public Guid? IVRId { get; set; }

        /// <summary>IVR unique id or empty for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? ContextId { get; set; }

        public string? Title { get; set; }
    }
}
