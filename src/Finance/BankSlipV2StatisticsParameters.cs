using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Defines the bounded window used by the bank slip operational summary.
    /// </summary>
    public class BankSlipV2StatisticsParameters
    {
        public Guid? ContextId { get; set; }
        public int WindowHours { get; set; } = 24;
    }
}
