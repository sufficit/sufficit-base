using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class ExternalCallTTSRequest : ExternalCallRequest
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Text { get; set; }

        public override string? Extension => "sufficit-app-system-call-tts,s,1";
    }
}
