using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class ExternalCallTTSRequest : ExternalCallRequest
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Text { get; set; }

        public override string? Asterisk => "sufficit-app-system-call-tts,s,1";
    }
}
