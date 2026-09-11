using System;

namespace Sufficit.Sales
{
    /// <summary>Capacity limits for one contract, not additive monthly allocations.</summary>
    public sealed class QuotaSpecification
    {
        public int MaxInstances { get; set; }
        public int MaxCpu { get; set; }
        public int MaxMemoryMb { get; set; }
        public int MaxDiskGb { get; set; }
        public int MaxConnections { get; set; }
        public bool AllowAdb { get; set; }
        public bool AllowVpn { get; set; }
    }

    /// <summary>Explicit checkout offer. Never enrolls or bills existing contracts.</summary>
    public sealed class ServiceQuotaProfile
    {
        public Guid CatalogItemId { get; set; }
        public bool Enabled { get; set; }
        public QuotaSpecification Quota { get; set; } = new QuotaSpecification();
    }

    public sealed class RecurringQuotaChargeRequest
    {
        public Guid PeriodId { get; set; }
    }

    public sealed class RecurringQuotaChargeDto
    {
        /// <summary>Also the signed Checkout SessionId.</summary>
        public Guid Id { get; set; }
        public Guid PeriodId { get; set; }
        public Guid ContractId { get; set; }
        public Guid ContextId { get; set; }
        public Guid CatalogItemId { get; set; }
        public string CheckoutUrl { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        /// <summary>Financial instant supplied by the provider; absent for date-only/unknown sources.</summary>
        public DateTime? PaidAtUtc { get; set; }
        /// <summary>Original authenticated Paid webhook receipt, independently of the financial instant.</summary>
        public DateTime? ConfirmedReceiptUtc { get; set; }
        public DateTime ExpiresAtUtc { get; set; }
    }

    /// <summary>
    /// Paid capacity coverage for [PeriodStart, PeriodEnd). Consumers deduplicate by Id
    /// and renew the same contract's capacity; never sum its monthly quota snapshots.
    /// </summary>
    public sealed class RecurringQuotaGrantDto
    {
        public Guid Id { get; set; }
        public Guid ContextId { get; set; }
        public Guid CatalogItemId { get; set; }
        public Guid ContractId { get; set; }
        public Guid PeriodId { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        /// <summary>Optional financial instant supplied by the provider; never inferred.</summary>
        public DateTime? PaidAtUtc { get; set; }
        /// <summary>Authoritative Paid webhook receipt. The feed requires a valid value.</summary>
        public DateTime? ConfirmedReceiptUtc { get; set; }
        /// <summary>Central receipt time, never a substitute for the payment date.</summary>
        public DateTime ObservedAtUtc { get; set; }
        public QuotaSpecification Quota { get; set; } = new QuotaSpecification();
    }
}
