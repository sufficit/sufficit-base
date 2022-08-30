using Sufficit.Telephony.Asterisk;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Interactive Voice Response search parameters
    /// </summary>
    public class IVRSearchParameters
    {
        /// <summary>IVR unique id or empty for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? IVRId { get; set; }

        /// <summary>IVR unique id or empty for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? ContextId { get; set; }

        public string? Title { get; set; }
    }
}
