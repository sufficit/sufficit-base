#if NET10_0_OR_GREATER
using System;
namespace Sufficit.Telephony;

/// <summary>A request identifier belongs to one immutable call fingerprint.</summary>
public sealed class AgentVoiceCallConflictException() : InvalidOperationException("Request id already used with another call.");

/// <summary>Ledger evidence only. Acceptance does not prove answer, recording or audio.</summary>
public sealed record AgentVoiceCallStatus(Guid RequestId, string State, DateTime CreatedAtUtc,
    bool RedialAllowed = false, bool Answered = false, bool AudioVerified = false);
#endif
