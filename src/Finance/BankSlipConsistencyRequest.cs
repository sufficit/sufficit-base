using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Provider-neutral request for the periodic bank-slip integration audit.
    /// </summary>
    public sealed class BankSlipConsistencyRequest
    {
        public DateTime NowUtc { get; set; } = DateTime.UtcNow;
        public TimeSpan StaleAfter { get; set; } = TimeSpan.FromMinutes(15);
        public int BatchSize { get; set; } = 1000;
    }
}
