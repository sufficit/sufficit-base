using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Cadences
{
    /// <summary>Pure date arithmetic of a cadence. No storage, no side effects.</summary>
    public static class CadenceSchedule
    {
        public sealed class Due
        {
            public CadenceMilestone Milestone { get; set; } = new();
            public DateTime Date { get; set; }
            public bool Late { get; set; }
        }

        public static List<CadenceMilestone> Ordered(IEnumerable<CadenceMilestone> milestones)
            => milestones.OrderBy(m => m.OffsetDays).ThenBy(m => m.Order).ToList();

        /// <summary>All milestone dates for a D0 (preview).</summary>
        public static IEnumerable<Due> Dates(IEnumerable<CadenceMilestone> milestones, DateTime anchorDate)
            => Ordered(milestones).Select(m => new Due { Milestone = m, Date = anchorDate.Date.AddDays(m.OffsetDays) });

        /// <summary>
        ///     Milestones of an open case that are due on or before <paramref name="today"/> and were not emitted yet.
        ///     Late = due before today (catch-up after downtime or a D0 moved into the past).
        /// </summary>
        public static IEnumerable<Due> Pending(CadenceCase @case, DateTime today, ISet<string> emittedKeys)
        {
            if (@case.Status != CadenceCaseStatus.Open) yield break;
            foreach (var due in Dates(@case.Milestones, @case.AnchorDate))
            {
                if (due.Date > today.Date || emittedKeys.Contains(due.Milestone.Key)) continue;
                due.Late = due.Date < today.Date;
                yield return due;
            }
        }

        /// <summary>"-3", "0", "+5".</summary>
        public static string Format(int offsetDays) => offsetDays > 0 ? "+" + offsetDays : offsetDays.ToString();
    }
}
