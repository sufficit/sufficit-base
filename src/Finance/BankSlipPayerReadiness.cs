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
        /// <summary>Non-sensitive tenant UI preferences for authorized issuers.</summary>
        public bool AmountChangeOnWheel { get; set; }
        /// <summary>Allow ArrowUp/ArrowDown changes independently of mouse-wheel changes.</summary>
        public bool AmountChangeOnArrowKeys { get; set; } = true;
        public decimal AmountWheelStep { get; set; } = 1m;
        public IReadOnlyList<BankSlipPayerReadinessCheck> Checks { get; set; }
            = Array.Empty<BankSlipPayerReadinessCheck>();
    }
}
