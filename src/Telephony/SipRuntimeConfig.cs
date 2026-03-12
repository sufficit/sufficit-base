using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Runtime parameters for SIP client behavior, sent from the server to the softphone.
    /// All values are optional — clients must fall back to their own defaults if absent or invalid.
    /// </summary>
    public class SipRuntimeConfig
    {
        /// <summary>
        /// Time window (ms) after a SIP disconnection during which the client should treat
        /// the registration failure as a warning only.
        /// After this window, the client should escalate to an error state.
        /// Default: 180 000 ms (3 minutes). Client fallback if absent or invalid: same value.
        /// </summary>
        [JsonPropertyName("reconnectWatchdogErrorWindowMs")]
        [JsonPropertyOrder(1)]
        public int ReconnectWatchdogErrorWindowMs { get; set; } = 180_000;
    }
}
