using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     High-level outbound service families currently modeled by the experimental routing layer.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OutboundServiceType
    {
        /// <summary>
        ///     Unknown or not yet classified outbound service.
        /// </summary>
        UNKNOWN = 0,

        /// <summary>
        ///     Single-provider or single-route service.
        /// </summary>
        SINGLE = 1,

        /// <summary>
        ///     Flexible multi-route service.
        /// </summary>
        FLEX = 2,

        /// <summary>
        ///     Smart routing using customer-owned CLI pools.
        /// </summary>
        SMART_CUSTOMER = 3,

        /// <summary>
        ///     Smart routing using shared global CLI pools.
        /// </summary>
        SMART_GLOBAL = 4,

        /// <summary>
        ///     Bring-your-own-carrier routing.
        /// </summary>
        BYOC = 5
    }
}
