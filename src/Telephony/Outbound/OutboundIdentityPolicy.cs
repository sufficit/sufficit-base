using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Calling identity strategy requested by the outbound routing layer.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OutboundIdentityPolicy
    {
        /// <summary>
        ///     Use the default policy defined by the service type.
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        ///     Present a fixed DID chosen by telephony policy.
        /// </summary>
        FIXED_DID = 1,

        /// <summary>
        ///     Pick a DID from the customer's own smart pool.
        /// </summary>
        SMART_CUSTOMER = 2,

        /// <summary>
        ///     Pick a DID from the shared global smart pool.
        /// </summary>
        SMART_GLOBAL = 3,

        /// <summary>
        ///     Use the identity rules tied to a customer-managed trunk.
        /// </summary>
        CUSTOMER_TRUNK = 4
    }
}
