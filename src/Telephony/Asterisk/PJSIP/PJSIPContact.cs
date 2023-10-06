using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Asterisk.PJSIP
{
    public class PJSIPContact : PJSIPContactBase
    {
        [JsonPropertyName("id")]
        public string id { get; set; } = default!;
    }
}
