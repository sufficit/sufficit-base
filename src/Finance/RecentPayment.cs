using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// A received payment enriched with the customer and current account balance.
    /// </summary>
    public sealed class RecentPayment
    {
        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        public string ContextTitle { get; set; } = string.Empty;

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }

        public string Method { get; set; } = string.Empty;

        public string Kind { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Document { get; set; } = string.Empty;

        public decimal Value { get; set; }

        public decimal Balance { get; set; }

        public bool Active { get; set; }
    }
}
