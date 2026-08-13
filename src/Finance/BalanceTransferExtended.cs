namespace Sufficit.Finance
{
    /// <summary>
    ///     Financial transfer enriched with display names for its source and destination.
    /// </summary>
    public class BalanceTransferExtended : BalanceTransfer
    {
        public string? Source { get; set; }

        public string? Destination { get; set; }
    }
}
