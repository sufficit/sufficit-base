using System;

namespace Sufficit.Sales
{
    public sealed class LegacyServiceEditorState
    {
        public Guid ContractId { get; set; }
        public long Revision { get; set; }
        public InvoiceMsSql Service { get; set; } = default!;
    }

    public sealed class LegacyServiceChange
    {
        public Guid OperationId { get; set; }
        public Guid CutoverId { get; set; }
        public Guid ContractId { get; set; }
        public Guid ServiceId { get; set; }
        public long ExpectedRevision { get; set; }
        /// <summary>Only save and delete. A new service uses a separate creation command.</summary>
        public string Action { get; set; } = string.Empty;
        public InvoiceMsSql? Desired { get; set; }
    }

    public sealed class LegacyServiceChangeResult
    {
        public Guid OperationId { get; set; }
        public LegacyServiceEditorState? State { get; set; }
    }
}
