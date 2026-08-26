namespace Sufficit.Sales
{
    /// <summary>
    ///     Identifies the system that owns the original contract record.
    /// </summary>
    public enum ContractSource : byte
    {
        Native = 0,
        LegacySales = 1
    }
}
