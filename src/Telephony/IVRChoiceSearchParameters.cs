using Sufficit.Telephony.Asterisk;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Interactive Voice Response user choice
    /// </summary>
    public class IVRChoiceSearchParameters : IIVRChoiceSearchParameters
    {
        /// <summary>IVR unique id or empty for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [Required]
        public Guid IVRId { get; set; }

        /// <example><code>DateTime.Today</code></example>
        [Required]
        public DateTime Start { get; set; }

        public DateTime? End { get; set; }


        /// <example><code>false</code></example>
        public bool SourceExactMatch { get; set; }
        public string? Source { get; set; }


        /// <example><code>false</code></example>
        public bool DigitsExactMatch { get; set; }
        public string? Digits { get; set; }

        /// <example><code>0</code></example>
        public int Limit { get; set; }
    }
}
