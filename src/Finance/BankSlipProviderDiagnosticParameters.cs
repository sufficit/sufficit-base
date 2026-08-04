namespace Sufficit.Finance
{
    /// <summary>
    /// Provides the allow-listed inputs accepted by the provider diagnostics API.
    /// </summary>
    public sealed class BankSlipProviderDiagnosticParameters
    {
        public string Provider { get; set; } = string.Empty;

        public BankSlipProviderDiagnosticOperation Operation { get; set; }

        public string? ProviderChargeId { get; set; }
    }
}
