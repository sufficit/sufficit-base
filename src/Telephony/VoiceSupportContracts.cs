#if NET10_0_OR_GREATER
using System;
namespace Sufficit.Telephony;

/// <summary>Public identification fields of a DID; never destination or routing data.</summary>
public sealed record VoiceDidSummary(Guid Id, Guid ContextId, string Extension, string? Description);

/// <summary>Public identification fields of an endpoint; never credentials.</summary>
public sealed record VoiceEndPointSummary(Guid Id, string? Title, string? Description);

#endif
