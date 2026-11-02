using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// One service and competence charged by a bank slip. The items of a bank slip add up to its value.
    /// </summary>
    public class BankSlipItem
    {
        /// <summary>Customer that received the service; may differ from the payer (financial responsible).</summary>
        public Guid ContextId { get; set; }
        public Guid? ContractId { get; set; }
        /// <summary>Native contract period; mutually exclusive with <see cref="LegacyServiceId"/>.</summary>
        public Guid? PeriodId { get; set; }
        /// <summary>Legacy service cycle; mutually exclusive with <see cref="PeriodId"/>.</summary>
        public Guid? LegacyServiceId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CompetenceStart { get; set; }
        /// <summary>Exclusive end of the competence.</summary>
        public DateTime CompetenceEnd { get; set; }
        public decimal Amount { get; set; }
    }
}
