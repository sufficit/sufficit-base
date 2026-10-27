namespace Sufficit.Cadences
{
    public sealed class CadenceSearchParameters
    {
        public CadenceStatus? Status { get; set; }

        /// <summary>Only cadences that use this milestone key.</summary>
        public string? MilestoneKey { get; set; }

        public string? Text { get; set; }
    }
}
