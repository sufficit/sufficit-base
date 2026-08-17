using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Defines a bounded, read-only provider-to-database comparison.
    /// Dates represent calendar days in the provider's operating timezone.
    /// </summary>
    public sealed class BankSlipReconciliationRequest
    {
        public string Provider { get; set; } = BankSlipProviderCodes.Efi;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int MaximumItems { get; set; } = 2000;
    }
}
