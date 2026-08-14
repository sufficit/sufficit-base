using System;
using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>
    /// Presents the provider-aware, non-sensitive readiness of a payer before
    /// the durable issuance command is submitted.
    /// </summary>
    public class BankSlipPayerReadiness
    {
        public Guid ContextId { get; set; }
        public string Provider { get; set; } = string.Empty;
        public bool Ready { get; set; }
        public IReadOnlyList<BankSlipPayerReadinessCheck> Checks { get; set; }
            = Array.Empty<BankSlipPayerReadinessCheck>();
    }
}
