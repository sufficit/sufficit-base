using System;
using System.Collections.Generic;

namespace Sufficit.Sales
{
    /// <summary>Where a contract period stands in a schedule. Recommendation only; nothing is executed.</summary>
    public sealed class ServiceRuleEvaluation
    {
        public int RuleVersion { get; set; }

        /// <summary>Negative before the due date.</summary>
        public int DaysFromDue { get; set; }

        public bool Settled { get; set; }

        /// <summary>A termination step ran before payment; payment no longer restores the service.</summary>
        public bool Terminated { get; set; }

        /// <summary>Restriction currently in force (latest reached restriction/termination), if any.</summary>
        public ServiceRuleStep? ActiveRestriction { get; set; }

        public ServiceRuleStep? LastReached { get; set; }

        public ServiceRuleStep? Next { get; set; }

        public DateTime? NextDate { get; set; }

        public List<ServiceRuleStepOutcome> Steps { get; set; } = new();
    }
}
