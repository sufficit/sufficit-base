using System;
using System.ComponentModel.DataAnnotations;

namespace Sufficit.Cadences
{
    /// <summary>What a cadence applies to: a target type from <see cref="CadenceTargetTypes"/> and the owner's identifier.</summary>
    public sealed class CadenceTarget
    {
        public Guid Id { get; set; }

        public Guid CadenceId { get; set; }

        [Required, StringLength(64)]
        public string TargetType { get; set; } = string.Empty;

        /// <summary>Identifier in the owner's format (Guid "D" lowercase, key...); "*" with <see cref="CadenceTargetTypes.Everything"/>.</summary>
        [Required, StringLength(128)]
        public string TargetId { get; set; } = string.Empty;

        /// <summary>Display label captured when bound (the owner may rename it later).</summary>
        [StringLength(250)]
        public string? Title { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
