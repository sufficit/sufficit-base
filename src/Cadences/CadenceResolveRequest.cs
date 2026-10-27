using System.Collections.Generic;

namespace Sufficit.Cadences
{
    /// <summary>Which active cadence applies: candidates are tried from the most specific to the most general.</summary>
    public sealed class CadenceResolveRequest
    {
        public string Module { get; set; } = string.Empty;

        public CadenceKind Kind { get; set; }

        public List<CadenceTargetKey> Candidates { get; set; } = new();
    }
}
