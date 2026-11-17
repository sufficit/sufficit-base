namespace Sufficit.Telephony.InterConnection
{
    /// <summary>Controls the outbound identifier sent through a customer interconnection.</summary>
    public enum InterconnectionIdentifierForwarding
    {
        /// <summary>Use the interconnection's normal signaling without applying a route identifier.</summary>
        Disabled = 0,

        /// <summary>Use the identifier already resolved and authorized for the route.</summary>
        Generic = 1,

        /// <summary>Use the value configured by the customer on this interconnection.</summary>
        Fixed = 2
    }
}
