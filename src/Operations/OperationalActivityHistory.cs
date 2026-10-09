using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Operations
{
    /// <summary>An immutable accepted command receipt and historical state.</summary>
    public sealed class OperationalActivityHistory
    {
        /// <summary>Idempotent command identifier.</summary>
        public Guid RequestId { get; set; }
        /// <summary>Authenticated operator identity recorded by the server.</summary>
        public Guid ActorId { get; set; }
        /// <summary>Operator's mandatory explanation.</summary>
        public string Reason { get; set; } = string.Empty;
        /// <summary>Previous state; null for creation.</summary>
        public OperationalActivity? Before { get; set; }
        /// <summary>Accepted state at this revision, even if newer commands already exist.</summary>
        public OperationalActivity After { get; set; } = new OperationalActivity();
    }

    /// <summary>Explicit context and identity lookup; callers must enforce module authorization.</summary>
    public interface IOperationalActivityLookup
    {
        Task<OperationalActivity?> Get(Guid contextId, Guid activityId, CancellationToken token);
    }

    /// <summary>Authoritative work commands and context-scoped reads; no billing or provisioning effects.</summary>
    public interface IOperationalActivityStore
    {
        /// <summary>Accepts one revision or replays the identical actor-owned receipt.</summary>
        Task<OperationalActivityHistory> Apply(ActivityTransitionRequest request, Guid actorId, CancellationToken token);
        /// <summary>Reads a bounded context-scoped page ordered by stable activity identifier.</summary>
        Task<IReadOnlyList<OperationalActivity>> Search(Guid contextId, Guid? afterId, int limit, CancellationToken token);
        /// <summary>Reads bounded immutable history after the supplied revision.</summary>
        Task<IReadOnlyList<OperationalActivityHistory>> History(Guid contextId, Guid activityId, long afterRevision, int limit, CancellationToken token);
    }
}
