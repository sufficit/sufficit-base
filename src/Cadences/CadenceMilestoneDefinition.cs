using System.Collections.Generic;

namespace Sufficit.Cadences
{
    /// <summary>A milestone a module understands and reacts to. Key format: <c>&lt;module&gt;.&lt;name&gt;</c>.</summary>
    public sealed class CadenceMilestoneDefinition
    {
        public string Key { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        /// <summary>What the module does when the milestone is reached.</summary>
        public string? Description { get; set; }

        /// <summary>Owning module (display name).</summary>
        public string Module { get; set; } = string.Empty;

        /// <summary>Subject types the module can act on for this milestone; empty = any subject.</summary>
        public List<string> SubjectTypes { get; set; } = new();

        public bool Supports(string? subjectType)
            => SubjectTypes.Count == 0 || string.IsNullOrWhiteSpace(subjectType) || SubjectTypes.Contains(subjectType!);
    }
}
