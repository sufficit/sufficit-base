using System.Collections.Generic;

namespace Sufficit.Cadences
{
    /// <summary>Milestones contributed by the modules and whether cadences run in simulation.</summary>
    public sealed class CadenceCatalog
    {
        public bool Simulation { get; set; } = true;

        public List<CadenceMilestoneDefinition> Milestones { get; set; } = new();
    }
}
