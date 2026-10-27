using System;

namespace Sufficit.Cadences
{
    /// <summary>Immutable copy of a cadence as saved, with author and reason.</summary>
    public sealed class CadenceRevision
    {
        public Guid Id { get; set; }

        public Guid CadenceId { get; set; }

        public int Version { get; set; }

        public CadenceStatus Status { get; set; }

        public string? ChangedBy { get; set; }

        public string? Reason { get; set; }

        public DateTime ChangedAtUtc { get; set; } = DateTime.UtcNow;

        /// <summary>JSON of the cadence, steps and targets of this version.</summary>
        public string Snapshot { get; set; } = string.Empty;
    }
}
