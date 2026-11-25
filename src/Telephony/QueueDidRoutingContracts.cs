using System;

namespace Sufficit.Telephony;

/// <summary>Expected queue route of a DID, compared with the dialplan state.</summary>
public sealed record QueueDidRouteSnapshot(Guid DidId, Guid ContextId, string? ExpectedAsterisk,
    Guid? ExpectedDestinationId, string? ExpectedTypeName, bool? ExpectedAnswer, bool ExpectedBilled)
{
    public QueueDidRouteSnapshot() : this(Guid.Empty, Guid.Empty, null, null, null, null, false) { }
}

public sealed record QueueDidRouteChange(Guid ContextId, Guid QueueId, bool RingingOnly,
    string? ExpectedAsterisk, Guid? ExpectedDestinationId, string? ExpectedTypeName, bool? ExpectedAnswer, bool ExpectedBilled);
