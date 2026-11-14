using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Support
{
    /// <summary>Result of a write: the thread after the change, the message written and whether it was a replay.</summary>
    public sealed class SupportWriteResult
    {
        public SupportThread Thread { get; set; } = new SupportThread();
        public SupportMessage Message { get; set; } = new SupportMessage();
        /// <summary>True when the request id was already accepted; nothing changed and no event must be raised.</summary>
        public bool Replayed { get; set; }
    }

    /// <summary>Persistence of support threads. The caller resolves the side and author from authentication.</summary>
    public interface ISupportThreadStore
    {
        Task<SupportWriteResult> Open(SupportThreadOpenRequest request, string side, Guid authorId, CancellationToken cancellationToken);
        /// <exception cref="KeyNotFoundException">Thread not found in the context.</exception>
        /// <exception cref="SupportConflictException">Expected revision differs.</exception>
        Task<SupportWriteResult> Reply(Guid contextId, Guid threadId, SupportMessageRequest request, string side, Guid authorId, CancellationToken cancellationToken);
        Task<IReadOnlyList<SupportThread>> Search(SupportThreadSearch search, CancellationToken cancellationToken);
        Task<SupportThreadDetail?> Get(Guid contextId, Guid threadId, CancellationToken cancellationToken);
    }
}
