using System;

namespace Sufficit.Telephony.DIDs;

/// <summary>Ownership is distinct from routing. Commercial coverage cannot release an isolated line.</summary>
public static class DIDBindingEligibility
{
    public static bool IsIsolated(DirectInwardDialing did) =>
        string.Equals(did.Asterisk, "sufficit-app-blackhole,isolated,1", StringComparison.OrdinalIgnoreCase) ||
        string.Equals(did.Asterisk, "app-blackhole,isolated,1", StringComparison.OrdinalIgnoreCase);

    public static void Require(DirectInwardDialing did, Guid customer)
    {
        if (did == null || customer == Guid.Empty)
            throw new ArgumentException("Verified DID and customer are required.");
        // Empty routing context is also used by isolated/quarantined inventory. It
        // is not permission to allocate a line, even when commercial coverage exists.
        if (IsIsolated(did))
            throw new InvalidOperationException("Isolated DID requires an explicit telephony release before binding.");
        if (did.OwnerId.HasValue && did.OwnerId.Value != Guid.Empty && did.OwnerId.Value != customer)
            throw new InvalidOperationException("DID has a different explicit owner.");
        // Matching OwnerId must not reconnect a line parked in a blocking context.
        if (did.ContextId != Guid.Empty && did.ContextId != customer)
            throw new InvalidOperationException("DID routing context requires separate telephony review.");
    }
}
