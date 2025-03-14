using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.WebRTC
{
    /// <summary>
    ///     WebRTC user preferences
    /// </summary>
    public class WebRTCPreferences
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonPropertyName("autostartup")]
        public bool AutoStartUp { get; set; }
#if !DEBUG
            = true;
#endif

        /// <summary>
        ///     Delay before startup, means that its not so important at this moment
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("startupdelay")]
        public TimeSpan StartUpDelay { get; set; } = TimeSpan.FromSeconds(30);

        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonPropertyName("registeratstartup")]
        public bool RegisterAtStartUp { get; set; } = true;
    }
}
