using Sufficit.Telephony.Asterisk;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("ivrId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid IVRId { get; set; }

        /// <example><code>DateTime.Today</code></example>
        [Required]
        [JsonPropertyName("start")]
        public DateTime Start { get; set; }

        [JsonPropertyName("end")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? End { get; set; }


        /// <example><code>false</code></example>
        public bool SourceExactMatch { get; set; }
        public string? Source { get; set; }


        /// <example><code>false</code></example>
        public bool DigitsExactMatch { get; set; }
        public string? Digits { get; set; }

        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        /// <example><code>0</code></example>
        public int Limit { get; set; }
    }
}
