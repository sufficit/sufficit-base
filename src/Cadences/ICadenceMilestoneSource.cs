using System.Collections.Generic;

namespace Sufficit.Cadences
{
    /// <summary>
    ///     Implemented by each module and registered in DI to contribute the milestones it reacts to. The cadence core
    ///     only aggregates these definitions; what happens on each milestone is the module's own configuration.
    /// </summary>
    public interface ICadenceMilestoneSource
    {
        IEnumerable<CadenceMilestoneDefinition> GetMilestones();
    }
}
