using System;

namespace Sufficit.Sales
{
    public sealed class ServiceRuleStepOutcome
    {
        public ServiceRuleStep Step { get; set; } = new();

        public DateTime Date { get; set; }

        public ServiceRuleStepState State { get; set; }

        public string? Reason { get; set; }
    }
}
