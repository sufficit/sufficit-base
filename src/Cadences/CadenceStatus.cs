namespace Sufficit.Cadences
{
    /// <summary>Lifecycle of a cadence. Only active cadences are followed by consumers.</summary>
    public enum CadenceStatus : byte
    {
        Draft = 0,
        Active = 1,
        Retired = 2
    }
}
