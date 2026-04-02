using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Matching mode imported from the legacy dialout_groups matrix.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OutboundRouteRuleMatchMode
    {
        /// <summary>
        ///     Unknown or not yet classified route rule.
        /// </summary>
        UNKNOWN = 0,

        /// <summary>
        ///     Non-identified legacy route selected before CLI routes.
        /// </summary>
        ANONYMOUS = 1,

        /// <summary>
        ///     CLI route that accepts an open caller provider.
        /// </summary>
        CLI_OPEN = 2,

        /// <summary>
        ///     CLI route that expects a caller DID from one specific provider.
        /// </summary>
        CLI_PROVIDER = 3
    }
}
