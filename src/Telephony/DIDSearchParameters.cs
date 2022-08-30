using Sufficit.Telephony.Asterisk;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Direct Inward Dialing search parameters
    /// </summary>
    public class DIDSearchParameters
    {
        /// <summary>Object unique id or null for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? DIDId { get; set; }

        /// <summary>Object unique id, null for all or empty for free</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? ContextId { get; set; }

        /// <summary>Object Provider unique id or null for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? ProviderId { get; set; }

        public string? Extension { get; set; }

        public bool? Billed { get; set; }
    }
}
