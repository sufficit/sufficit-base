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
    public interface IIVRChoiceSearchParameters
    {
        /// <summary>IVR unique id or empty for all</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [Required]
        Guid IVRId { get; }

        /// <example><code>DateTime.Today</code></example>
        [Required]
        DateTime Start { get; }

        DateTime? End { get; }


        /// <example><code>false</code></example>
        bool SourceExactMatch { get; }
        string Source { get; }


        /// <example><code>false</code></example>
        bool DigitsExactMatch { get; }
        string Digits { get; }

        /// <example><code>0</code></example>
        int Limit { get; }
    }
}
