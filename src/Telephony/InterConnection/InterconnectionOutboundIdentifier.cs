namespace Sufficit.Telephony.InterConnection
{
    /// <summary>Resolves an identifier for a single outbound attempt after route eligibility is known.</summary>
    public static class InterconnectionOutboundIdentifier
    {
        /// <summary>
        /// Resolves the value to apply to outgoing signaling. Successful resolution can yield
        /// no override when forwarding is disabled. Generic mode expects an already authorized
        /// route identifier. Fixed mode uses the customer-supplied value without DID lookup.
        /// </summary>
        public static bool TryResolve(InterconnectionIdentifierForwarding forwarding, string? routeIdentifier,
            string? fixedIdentifier, out string? identifier)
        {
            identifier = null;
            switch (forwarding)
            {
                case InterconnectionIdentifierForwarding.Disabled:
                    return true;
                case InterconnectionIdentifierForwarding.Generic:
                    identifier = routeIdentifier;
                    break;
                case InterconnectionIdentifierForwarding.Fixed:
                    identifier = fixedIdentifier;
                    break;
            }

            if (!string.IsNullOrWhiteSpace(identifier))
                return true;

            identifier = null;
            return false;
        }
    }
}
