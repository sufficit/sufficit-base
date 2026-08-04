using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Administrative, token-safe view of one received provider callback.
    /// </summary>
    public sealed class BankSlipProviderNotificationView
    {
        public Guid Id { get; set; }
        public Guid BankSlipId { get; set; }
        public string Provider { get; set; } = string.Empty;
        public string TokenFingerprint { get; set; } = string.Empty;
        public DateTime ReceivedAtUtc { get; set; }
        public DateTime? ProcessedAtUtc { get; set; }
        public int AttemptCount { get; set; }
        public string? Result { get; set; }
        public string? Error { get; set; }
        public int StoredEventCount { get; set; }
    }
}
