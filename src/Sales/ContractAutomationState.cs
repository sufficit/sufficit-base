using System;

namespace Sufficit.Sales
{
    /// <summary>Central decision for explicit monthly automation of a saved contract.</summary>
    public sealed class ContractAutomationState
    {
        public Guid ContractId { get; set; }
        public Guid ContextId { get; set; }
        public bool Enabled { get; set; }
        public bool CanEnable { get; set; }
        public string? BlockReason { get; set; }
    }

    public sealed class ContractAutomationRequest
    {
        public Guid ContractId { get; set; }
        public bool Enabled { get; set; }
        public bool ExpectedEnabled { get; set; }
    }
}
