using System;

namespace Sufficit.Sales
{
    /// <summary>Immutable copy of a schedule as saved, with author and reason.</summary>
    public sealed class ServiceRuleRevision
    {
        public Guid Id { get; set; }

        public Guid RuleId { get; set; }

        public int Version { get; set; }

        public ServiceRuleStatus Status { get; set; }

        public string? ChangedBy { get; set; }

        public string? Reason { get; set; }

        public DateTime ChangedAtUtc { get; set; } = DateTime.UtcNow;

        /// <summary>JSON of the steps and bindings of this version.</summary>
        public string Snapshot { get; set; } = string.Empty;
    }
}
