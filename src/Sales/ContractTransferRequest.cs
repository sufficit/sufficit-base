using System;

namespace Sufficit.Sales
{
    /// <summary>Immediate commercial transfer. TransferId is also the destination contract id and retry key.</summary>
    public sealed class ContractTransferRequest
    {
        public Guid TransferId { get; set; }
        public Guid ContractId { get; set; }
        public Guid SourceContextId { get; set; }
        public Guid DestinationContextId { get; set; }
        public DateTime ExpectedUpdatedAtUtc { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
