using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Monitor
{
    /// <summary>
    /// Mode used by telephony live monitor actions.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TelephonyMonitorActionMode
    {
        /// <summary>
        /// Supervisor hears the target call without speaking.
        /// </summary>
        Listen = 0,

        /// <summary>
        /// Supervisor hears the target call and may talk to the monitored extension.
        /// </summary>
        Whisper = 1
    }
}
