namespace Sufficit.Cadences
{
    public sealed class CadenceSearchParameters
    {
        public string? Module { get; set; }

        public CadenceKind? Kind { get; set; }

        public CadenceStatus? Status { get; set; }

        /// <summary>Only cadences bound to this target (both type and id required).</summary>
        public string? TargetType { get; set; }

        public string? TargetId { get; set; }

        public string? Text { get; set; }
    }
}
