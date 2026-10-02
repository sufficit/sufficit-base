using System;

namespace Sufficit.Sales
{
    /// <summary>Last observed source service, distinct from the aggregate contract identity.</summary>
    /// <remarks>Migration evidence only. Never replay this snapshot as a new credit or enable
    /// renewal from it without writer handoff. Dates retain source precision and Kind.</remarks>
    public sealed class LegacyRenewalSnapshot
    {
        public const string ParameterKey = "migration.legacy_renewal_snapshot_v1";
        public int Code { get; set; }
        public Guid ServiceId { get; set; }
        public Guid ContextId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime? Billing { get; set; }
        public DateTime SourceUpdatedAt { get; set; }
        public decimal? Value { get; set; }
        public Guid? CommissionedId { get; set; }
        public decimal? Commission { get; set; }
        public bool Renewed { get; set; }
        public ServiceDiscountEvidence? Discount { get; set; }
    }
}
