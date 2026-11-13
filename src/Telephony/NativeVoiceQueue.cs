#if NET10_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace Sufficit.Telephony;

/// <summary>Native queue member. <c>EndPointId</c> names an AI voice agent member by id (agents may have no number); null for classic members.</summary>
public sealed record NativeVoiceQueueMember(Guid Id, Guid Owner, string Extension, Guid Revision, Guid? EndPointId = null)
{
    /// <summary>Binary compatibility for consumers compiled before <c>EndPointId</c>.</summary>
    public NativeVoiceQueueMember(Guid Id, Guid Owner, string Extension, Guid Revision) : this(Id, Owner, Extension, Revision, null) { }
}
public sealed record NativeVoiceQueue(Guid Id, Guid ContextId, string Title, int WaitSeconds, Guid Revision);
public sealed record NativeVoiceQueueSnapshot(NativeVoiceQueue Queue, IReadOnlyList<NativeVoiceQueueMember> Members)
{
    // Include every member revision, not only extension text: a concurrent pause/edit must be noticed.
    public string Revision => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(
        Queue.Revision.ToString("N") + string.Concat(Members.OrderBy(m => m.Id).Select(m => $"|{m.Id:N}:{m.Owner:N}:{m.Extension}:{m.Revision:N}" + (m.EndPointId is Guid e ? ":" + e.ToString("N") : ""))))));
}

#endif
