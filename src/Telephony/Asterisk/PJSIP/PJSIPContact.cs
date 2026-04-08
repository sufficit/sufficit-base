using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using Sufficit;

namespace Sufficit.Telephony.Asterisk.PJSIP
{
    public class PJSIPContact : PJSIPContactBase, ITimestamp
    {
        [JsonPropertyName("id")]
        public string id { get; set; } = default!;

        [JsonIgnore]
        public DateTime CreatedAtUtc { get; set; }

        [JsonIgnore]
        public DateTime? UpdatedAtUtc { get; set; }

        [JsonIgnore]
        public DateTime? DeletedAtUtc { get; set; }
    }
}
