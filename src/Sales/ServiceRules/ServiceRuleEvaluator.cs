using System;
using System.Linq;

namespace Sufficit.Sales
{
    /// <summary>Deterministic, side-effect free placement of a contract period in a schedule.</summary>
    public static class ServiceRuleEvaluator
    {
        public static ServiceRuleEvaluation Evaluate(ServiceRule rule, ServiceRuleCase @case)
        {
            if (rule == null) throw new ArgumentNullException(nameof(rule));
            if (@case == null) throw new ArgumentNullException(nameof(@case));

            var due = @case.DueDate.Date;
            var today = @case.ReferenceDate.Date;
            var paid = @case.PaidDate?.Date;
            var result = new ServiceRuleEvaluation
            {
                RuleVersion = rule.Version,
                DaysFromDue = (int)(today - due).TotalDays,
                Settled = paid.HasValue && paid.Value <= today,
            };

            foreach (var step in ServiceRuleValidator.Ordered(rule.Steps))
            {
                var outcome = new ServiceRuleStepOutcome { Step = step, Date = due.AddDays(step.OffsetDays) };
                if (result.Settled && outcome.Date > paid!.Value)
                {
                    outcome.State = ServiceRuleStepState.Cancelled;
                    outcome.Reason = "pago antes desta etapa";
                }
                else if (outcome.Date > today)
                {
                    outcome.State = ServiceRuleStepState.Upcoming;
                }
                else if (@case.AutomaticPayment && string.Equals(step.Condition, ServiceRuleConditions.SkipWhenAutomaticPayment, StringComparison.OrdinalIgnoreCase))
                {
                    outcome.State = ServiceRuleStepState.Skipped;
                    outcome.Reason = "pagamento automático";
                }
                else
                {
                    outcome.State = ServiceRuleStepState.Reached;
                }

                result.Steps.Add(outcome);
            }

            var reached = result.Steps.Where(o => o.State == ServiceRuleStepState.Reached).ToList();
            result.LastReached = reached.LastOrDefault()?.Step;
            result.Terminated = reached.Any(o => ServiceRuleActions.Find(o.Step.Action)?.Category == ServiceRuleActionCategory.Termination);

            var restriction = reached.LastOrDefault(o =>
                ServiceRuleActions.Find(o.Step.Action)?.Category is ServiceRuleActionCategory.Restriction or ServiceRuleActionCategory.Termination);
            var lifted = result.Settled && rule.ReactivateOnPayment && !result.Terminated;
            result.ActiveRestriction = lifted ? null : restriction?.Step;

            var next = result.Steps.FirstOrDefault(o => o.State == ServiceRuleStepState.Upcoming);
            result.Next = next?.Step;
            result.NextDate = next?.Date;
            return result;
        }
    }
}
