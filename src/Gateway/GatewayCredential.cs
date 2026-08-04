namespace Sufficit.Gateway
{
    /// <summary>
    /// Carries a provider credential resolved from protected host
    /// configuration. Values must never be persisted in domain records.
    /// </summary>
    public class GatewayCredential
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? ApiKey { get; set; }
    }
}
