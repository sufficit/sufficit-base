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

        /// <summary>Start of the new authority's UTC, half-open grant interval.</summary>
        public DateTime? StartUtc { get; set; }

        public DateTime? ExpirationUtc { get; set; }

        /// <summary>Null marks a legacy projection that has not been migrated.</summary>
        public OutboundAdministrativeState? AdministrativeState { get; set; }

        public long? Revision { get; set; }

        public string? ValidityOwner { get; set; }

        public string? ExternalContractLineId { get; set; }

        public long? SourceVersion { get; set; }

        public string? SourceEventId { get; set; }

        public string? SourceSystem { get; set; }

        public string? Comments { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }

        public bool IsActiveAt(DateTime utcNow)
            => AdministrativeState.HasValue
                ? IsEligibleAt(utcNow)
                : Channels > 0 && (!ExpirationUtc.HasValue || ExpirationUtc.Value >= utcNow);

        /// <summary>Strict eligibility for the new executor; legacy projections remain excluded until migrated.</summary>
        public bool IsEligibleAt(DateTime utcNow)
            => Channels > 0
                && AdministrativeState == OutboundAdministrativeState.Enabled
                && OutboundValidity.Contains(StartUtc, ExpirationUtc, utcNow);
    }
}
