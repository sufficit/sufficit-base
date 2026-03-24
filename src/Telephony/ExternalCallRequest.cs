using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class ExternalCallRequest : CallRequestProperties
    {
        /// <summary>
        ///     External destination phone
        /// </summary>
        [Required]
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = default!;

        /// <summary>
        /// Optional flag that enables answering machine detection in the dialplan callback flow.
        /// Null means disabled.
        /// </summary>
        [JsonPropertyName("amd")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Amd { get; set; }
    }
}
