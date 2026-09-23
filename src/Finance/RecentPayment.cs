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

        /// <summary>
        /// True when the bank already reported the receipt but the provider has
        /// not confirmed the payment yet (e.g. Efí "identified"). The row is
        /// provisional: value is near-certain, confirmation is not.
        /// </summary>
        public bool PendingConfirmation { get; set; }
    }
}
