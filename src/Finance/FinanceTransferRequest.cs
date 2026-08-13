using System;

namespace Sufficit.Finance
{
    /// <summary>
    ///     Request to transfer value between two financial contexts.
    /// </summary>
    public sealed class FinanceTransferRequest
    {
        public Guid SourceId { get; set; }

        public Guid DestinationId { get; set; }

        public decimal Amount { get; set; }

        /// <summary>
        ///     Accounting date in UTC. Defaults to the current instant.
        /// </summary>
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime? Timestamp { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
