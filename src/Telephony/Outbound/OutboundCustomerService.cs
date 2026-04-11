using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Telephony-side projection of one outbound service currently owned by the customer.
    /// </summary>
    public class OutboundCustomerService
    {
        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        public Guid ServiceId { get; set; }

        public int Channels { get; set; }

        public int Quantity { get; set; } = 1;

        public DateTime? ExpirationUtc { get; set; }

        public string? SourceEventId { get; set; }

        public string? SourceSystem { get; set; }

        public string? Comments { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }

        public bool IsActiveAt(DateTime utcNow)
            => Channels > 0
                && (!ExpirationUtc.HasValue || ExpirationUtc.Value >= utcNow);
    }
}
