using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public class WebCallBackRequest : CallRequestProperties
    {
        [JsonIgnore]
        [Obsolete("use ContextId instead")]
        public Guid IDContext { get => ContextId; set => ContextId = value; }

        /// <summary>
        /// Destination phone
        /// </summary>
        [Required]
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = default!;
    }
}
