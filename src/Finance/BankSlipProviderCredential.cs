namespace Sufficit.Finance
{
    /// <summary>
    /// Carries credentials resolved from protected configuration for one gateway call.
    /// </summary>
    public class BankSlipProviderCredential
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? ApiKey { get; set; }
    }
}
