#if NET10_0_OR_GREATER
using System;

namespace Sufficit.Telephony;

/// <summary>Agent virtual extension registration. <c>Number</c> is an optional internal alias; without it the agent is reachable by id only.</summary>
public sealed record AgentEndPointRegistration(Guid ContextId, string? Number, string Title, string SipUri);
public sealed record AgentEndPointDirectoryItem(Guid Id, Guid ContextId, string? Number, string Title, string Surface, bool Enabled, bool Recording, DateTime CreatedAtUtc, bool Virtual = true, bool CanRegister = false);
public sealed record AgentEndPointDirectory(AgentEndPointDirectoryItem[] Items, bool Truncated);
public sealed record AgentEndPointCall(Guid RequestId, Guid ContextId, string Number, string Purpose);

/// <summary>Transport snapshot independent of the persistence model. Keeps the existing agent JSON contract.</summary>
public sealed class AgentEndPointDetails
{
    public Guid Id { get; set; }
    public Guid ContextId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Surface { get; set; }
    public bool Recording { get; set; } = true;
    public bool? CallerIdForwarding { get; set; }
    public string? OutboundCallerId { get; set; }
    public string? SipUri { get; set; }
    public bool Enabled { get; set; } = true;
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public DateTime? DeletedAtUtc { get; set; }
}
#endif
