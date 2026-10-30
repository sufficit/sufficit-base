using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Operations
{
    /// <summary>
    ///     Team work queue of one activity type across every context (e.g. collection notices anyone may take).
    ///     Callers must restrict the type to what the operator may manage.
    /// </summary>
    public sealed class OperationalActivityQueueQuery
    {
        /// <summary>Required activity category.</summary>
        public string ActivityType { get; set; } = string.Empty;
        /// <summary>True: Open, InProgress and WaitingExternal. False: Completed and Canceled.</summary>
        public bool Open { get; set; } = true;
        /// <summary>Only for closed work: last change at or after this instant.</summary>
        public DateTime? UpdatedSinceUtc { get; set; }
        /// <summary>Between 1 and 500.</summary>
        public int Limit { get; set; } = 200;
    }

    public interface IOperationalActivityQueue
    {
        /// <summary>Open work ordered by deadline then identity; closed work newest first.</summary>
        Task<IReadOnlyList<OperationalActivity>> Queue(OperationalActivityQueueQuery query, CancellationToken token);
    }
}
