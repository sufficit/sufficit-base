using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Interactive Voice Response search parameters
    /// </summary>
    public class IVRSearchParameters : ILimit
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

        /// <summary>
        /// IVR title, can be partial or full match
        /// </summary>
        public TextFilter? Title { get; set; }

        /// <summary>
        /// Extension to be used when direct dialing to an IVR
        /// </summary>
        public string? Extension { get; set; }

        /// <summary>
        /// FreePBX identifier, if any
        /// Used to link with FreePBX system, if any
        /// </summary>
        public int? FPBXId { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        public uint? Limit { get; set; }
    }
}
