using System;

namespace Sufficit.Sales
{
    public sealed class LegacyServiceEditorState
    {
        public Guid ContractId { get; set; }
        public long Revision { get; set; }
        public SalesRecord Service { get; set; } = default!;
        public ServiceDiscountEvidence? Discount { get; set; }
    }

    public sealed class LegacyServiceChange
    {
        public Guid OperationId { get; set; }
        public Guid CutoverId { get; set; }
        public Guid ContractId { get; set; }
        public Guid ServiceId { get; set; }
        public long ExpectedRevision { get; set; }
        /// <summary>create, save, renew or delete. Creation requires empty service/contract IDs and revision zero.</summary>
        public string Action { get; set; } = string.Empty;
        public SalesRecord? Desired { get; set; }
        public ServiceDiscountRequest? Discount { get; set; }
    }

    public sealed class LegacyServiceChangeResult
    {
        public Guid OperationId { get; set; }
        public LegacyServiceEditorState? State { get; set; }
        public LegacyServiceRenewalEvidence? RenewalEvidence { get; set; }
    }
}
