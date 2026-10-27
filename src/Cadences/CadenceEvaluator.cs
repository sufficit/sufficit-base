using System;
using System.Linq;

namespace Sufficit.Cadences
{
    /// <summary>Deterministic, side-effect free placement of a case in a cadence.</summary>
    public static class CadenceEvaluator
    {
        public static CadenceEvaluation Evaluate(Cadence cadence, CadenceCase @case)
        {
            if (cadence == null) throw new ArgumentNullException(nameof(cadence));
            if (@case == null) throw new ArgumentNullException(nameof(@case));

            var anchor = @case.AnchorDate.Date;
            var today = @case.ReferenceDate.Date;
            var resolved = @case.ResolvedDate?.Date;
            var result = new CadenceEvaluation
            {
                CadenceVersion = cadence.Version,
                DaysFromAnchor = (int)(today - anchor).TotalDays,
                Resolved = resolved.HasValue && resolved.Value <= today,
            };

            foreach (var step in CadenceValidator.Ordered(cadence.Steps))
            {
                var outcome = new CadenceStepOutcome { Step = step, Date = anchor.AddDays(step.OffsetDays) };
                if (result.Resolved && outcome.Date > resolved!.Value)
                {
                    outcome.State = CadenceStepState.Cancelled;
                    outcome.Reason = "resolvido antes desta etapa";
                }
                else if (outcome.Date > today)
                {
                    outcome.State = CadenceStepState.Upcoming;
                }
                else if (!string.IsNullOrWhiteSpace(step.Condition) && @case.Facts.Contains(step.Condition!))
                {
                    outcome.State = CadenceStepState.Skipped;
                    outcome.Reason = CadenceConditions.All.TryGetValue(step.Condition!, out var label) ? label : step.Condition;
                }
                else
                {
                    outcome.State = CadenceStepState.Reached;
                }

                result.Steps.Add(outcome);
            }

            var reached = result.Steps.Where(o => o.State == CadenceStepState.Reached).ToList();
            result.LastReached = reached.LastOrDefault()?.Step;
            result.Terminated = reached.Any(o => CadenceActions.Find(o.Step.Action)?.Category == CadenceActionCategory.Termination);

            var restriction = reached.LastOrDefault(o =>
                CadenceActions.Find(o.Step.Action)?.Category is CadenceActionCategory.Restriction or CadenceActionCategory.Termination);
            var lifted = result.Resolved && cadence.RestoreOnResolution && !result.Terminated;
            result.ActiveRestriction = lifted ? null : restriction?.Step;

            var next = result.Steps.FirstOrDefault(o => o.State == CadenceStepState.Upcoming);
            result.Next = next?.Step;
            result.NextDate = next?.Date;
            return result;
        }
    }
}
