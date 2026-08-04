namespace Sufficit.Finance
{
    /// <summary>
    /// Represents the private provider source resolved for a valid public bank slip capability.
    /// </summary>
    public sealed class BankSlipV2PublicDocumentSource
    {
        public string Provider { get; set; } = string.Empty;
        public string ProviderPdfUrl { get; set; } = string.Empty;

        /// <summary>
        /// Legacy preferred provider URL retained while existing rows are reconciled.
        /// </summary>
        public string ProviderUrl { get; set; } = string.Empty;
    }
}
