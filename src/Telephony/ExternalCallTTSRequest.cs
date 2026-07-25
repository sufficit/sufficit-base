using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Starts an external call that speaks dynamic text and hangs up when playback finishes.
    /// </summary>
    public class ExternalCallTTSRequest : ExternalCallRequest
    {
        /// <summary>
        /// Canonical dialplan destination for the platform text-to-speech application.
        /// </summary>
        public const string AsteriskTarget = "sufficit-app-system-call-tts,s,1";

        /// <summary>
        /// Text rendered to the called party after the external destination answers.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Text { get; set; }

        /// <summary>
        /// Routes this request to the canonical text-to-speech application.
        /// </summary>
        public override string? Asterisk => AsteriskTarget;
    }
}
