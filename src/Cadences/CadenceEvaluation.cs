using System;
using System.Collections.Generic;

namespace Sufficit.Cadences
{
    /// <summary>Where a case stands in a cadence. Recommendation only; nothing is executed.</summary>
    public sealed class CadenceEvaluation
    {
        public int CadenceVersion { get; set; }

        /// <summary>Negative before the anchor date.</summary>
        public int DaysFromAnchor { get; set; }

        public bool Resolved { get; set; }

        /// <summary>A termination step ran before resolution; resolving no longer restores anything.</summary>
        public bool Terminated { get; set; }

        /// <summary>Restriction currently in force (latest reached restriction/termination), if any.</summary>
        public CadenceStep? ActiveRestriction { get; set; }

        public CadenceStep? LastReached { get; set; }

        public CadenceStep? Next { get; set; }

        public DateTime? NextDate { get; set; }

        public List<CadenceStepOutcome> Steps { get; set; } = new();
    }
}
