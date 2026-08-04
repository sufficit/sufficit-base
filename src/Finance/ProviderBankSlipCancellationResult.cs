namespace Sufficit.Finance
{
    /// <summary>
    /// Represents a provider cancellation response translated into the stable domain.
    /// </summary>
    public class ProviderBankSlipCancellationResult
    {
        public string ProviderCode { get; set; } = string.Empty;
        public string ChargeId { get; set; } = string.Empty;
        public string ProviderStatus { get; set; } = string.Empty;
        public bool Canceled { get; set; }
    }
}
