using System;

namespace Sufficit.Cadences
{
    /// <summary>A candidate target used to resolve which cadence applies to a case.</summary>
    public sealed class CadenceTargetKey
    {
        public CadenceTargetKey() { }

        public CadenceTargetKey(string targetType, string targetId)
        {
            TargetType = targetType;
            TargetId = targetId;
        }

        public CadenceTargetKey(string targetType, Guid targetId) : this(targetType, targetId.ToString("D")) { }

        public string TargetType { get; set; } = string.Empty;

        public string TargetId { get; set; } = string.Empty;
    }
}
