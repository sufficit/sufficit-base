namespace Sufficit.Sales
{
    /// <summary>Describes one action a schedule step may request. Consumers implement the keys they support.</summary>
    public sealed class ServiceRuleActionDefinition
    {
        public string Key { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ServiceRuleActionCategory Category { get; set; }

        public ServiceRuleAudience DefaultAudience { get; set; }

        /// <summary>True when the action sends a message and accepts channels.</summary>
        public bool UsesChannels { get; set; }

        /// <summary>Systems expected to execute the action (e.g. "hermes", "endpoints").</summary>
        public string? Consumers { get; set; }

        /// <summary>Action that must appear earlier (lower offset, or same offset and lower order).</summary>
        public string? Requires { get; set; }
    }
}
