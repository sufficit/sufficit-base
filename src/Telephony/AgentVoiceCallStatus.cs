#if NET10_0_OR_GREATER
using System;
namespace Sufficit.Telephony;

/// <summary>A request identifier belongs to one immutable call fingerprint.</summary>
public sealed class AgentVoiceCallConflictException() : InvalidOperationException("Request id already used with another call.");

/// <summary>Immutable ledger acceptance plus optional correlated execution evidence; audio is never inferred.</summary>
public sealed record AgentVoiceCallStatus(Guid RequestId, string State, DateTime CreatedAtUtc,
    bool RedialAllowed = false, bool Answered = false, bool AudioVerified = false,
    AgentVoiceExecutionEvidence? Execution = null, DateTime? CheckedAtUtc = null,
    DateTime? SearchFromUtc = null, DateTime? SearchUntilUtc = null);

/// <summary>Observed CDR evidence is separate from the immutable originate acknowledgement.</summary>
public sealed record AgentVoiceExecutionEvidence(string State, string Source, string[] Dispositions,
    bool? Answered = null, bool AudioVerified = false);
#endif
