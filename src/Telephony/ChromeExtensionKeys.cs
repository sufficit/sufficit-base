namespace Sufficit.Telephony
{
    /// <summary>
    /// Well-known keys for <see cref="ChromeExtensionSetting"/>.
    /// </summary>
    public static class ChromeExtensionKeys
    {
        /// <summary>
        /// Guid (N format) of the SIP endpoint chosen by the user for the softphone.
        /// </summary>
        public const string Extension = "extension";

        /// <summary>
        /// User presence/availability state: "available" | "busy" | "unavailable".
        /// </summary>
        public const string Status = "status";

        /// <summary>
        /// Whether video calls are enabled: "true" | "false".
        /// </summary>
        public const string Video = "video";

        /// <summary>
        /// Auto-answer incoming calls: "true" | "false".
        /// </summary>
        public const string Answer = "answer";

        /// <summary>
        /// Ringtone URI or name. Empty string means default.
        /// </summary>
        public const string Ringtone = "ringtone";

        /// <summary>
        /// Microphone input device label/ID.
        /// </summary>
        public const string Microphone = "microphone";

        /// <summary>
        /// Speaker output device label/ID.
        /// </summary>
        public const string Speaker = "speaker";

        /// <summary>
        /// Time window (ms) after SIP disconnection before escalating to error state.
        /// Stored as integer string. Valid range: 30000–900000. Default: 180000.
        /// </summary>
        public const string ReconnectWatchdogErrorWindowMs = "sipRuntime.reconnectWatchdogErrorWindowMs";
    }
}