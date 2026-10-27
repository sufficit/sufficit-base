namespace Sufficit.Cadences
{
    /// <summary>Describes one action a step may request. Consumers implement the keys they support.</summary>
    public sealed class CadenceActionDefinition
    {
        public string Key { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public CadenceActionCategory Category { get; set; }

        public CadenceAudience DefaultAudience { get; set; }

        /// <summary>True when the action sends a message and accepts channels.</summary>
        public bool UsesChannels { get; set; }

        /// <summary>Module the action belongs to; empty = available to every module.</summary>
        public string Module { get; set; } = string.Empty;

        /// <summary>Systems expected to execute the action (e.g. "hermes", "endpoints").</summary>
        public string? Consumers { get; set; }

        /// <summary>Meaning of <see cref="CadenceStep.Parameters"/> for this action, shown as field label; null = unused.</summary>
        public string? ParametersLabel { get; set; }

        /// <summary>Action that must appear earlier (lower offset, or same offset and lower order).</summary>
        public string? Requires { get; set; }
    }
}
